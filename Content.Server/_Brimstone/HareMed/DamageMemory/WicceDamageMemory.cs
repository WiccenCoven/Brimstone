using System.Linq;
using Content.Server._Brimstone.HareMed.DamageMemory;
using Content.Shared.Damage;
using Content.Shared.Damage.Prototypes;
using Content.Shared.FixedPoint;
using Robust.Shared.Timing;
using Robust.Shared.Prototypes;

namespace Content.Server.Damage;

public sealed class DamageMemorySystem : EntitySystem
{
    [Dependency] private readonly DamageableSystem _damageable = default!;
    [Dependency] private readonly IGameTiming _timing = default!;
    [Dependency] private readonly IPrototypeManager _proto = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<WicceDamageMemoryComponent, DamageChangedEvent>(OnDamageChanged);
    }

    private bool IsDisallowedDamageType(WicceDamageMemoryComponent comp, ProtoId<DamageTypePrototype> type)
    {
        if (comp.DisallowedDamageTypes.Count == 0)
            return false;

        foreach (var group in _proto.EnumeratePrototypes<DamageGroupPrototype>())
        {
            if (!comp.DisallowedDamageTypes.Contains(group.ID))
                continue;

            if (group.DamageTypes.Contains(type))
                return true;
        }

        return false;
    }

    private void OnDamageChanged(EntityUid uid, WicceDamageMemoryComponent comp, DamageChangedEvent args)
    {
        var delta = args.DamageDelta;
        if (delta == null)
            return;

        foreach (var (type, change) in delta.DamageDict)
        {
            if (change >= 0)
                continue;

            var healed = -change;

            // Add it to the memory.
            if (!comp.Memory.TryGetValue(type, out var current))
                current = FixedPoint2.Zero;

            var newVal = current + healed;

            // Enforce per-type cap if necessary.
            if (comp.MaxMemoryPerType != FixedPoint2.Zero && newVal > comp.MaxMemoryPerType)
                newVal = comp.MaxMemoryPerType;

            comp.Memory[type] = newVal;
        }

        // Enforce global cap if necessary.
        if (comp.GlobalMemoryCap != FixedPoint2.Zero)
        {
            var total = comp.Memory.Values.Aggregate(FixedPoint2.Zero, (acc, v) => acc + v);
            if (total > comp.GlobalMemoryCap)
            {
                // Scale down proportionally so the total equals global cap.
                var scale = (double)(comp.GlobalMemoryCap / total);
                var keys = comp.Memory.Keys.ToArray();
                foreach (var k in keys)
                {
                    comp.Memory[k] = FixedPoint2.New(comp.Memory[k].Double() * scale);
                }
            }
        }

        // Schedule the first reapply if necessary.
        if (comp.NextReapply == TimeSpan.Zero || comp.NextReapply <= _timing.CurTime)
        {
            comp.NextReapply = _timing.CurTime + TimeSpan.FromSeconds(comp.ReapplyInterval);
        }
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var now = _timing.CurTime;

        var q = EntityQueryEnumerator<WicceDamageMemoryComponent, DamageableComponent>();
        while (q.MoveNext(out var uid, out var memComp, out var dmgComp))
        {
            if (memComp.Memory.Count == 0)
                continue;

            if (memComp.NextReapply > now)
                continue;

            var tickSeconds = memComp.ReapplyInterval;
            var amountPerTick = memComp.ReapplyPerSecond * FixedPoint2.New(tickSeconds);

            var toReapply = new DamageSpecifier();

            var keys = memComp.Memory.Keys.ToArray();
            foreach (var type in keys)
            {
                // Remove disallowed damage groups from the memory.
                if (IsDisallowedDamageType(memComp, type))
                {
                    memComp.Memory.Remove(type);
                    continue;
                }

                var available = memComp.Memory[type];
                if (available <= FixedPoint2.Zero)
                {
                    memComp.Memory.Remove(type);
                    continue;
                }

                var apply = FixedPoint2.Min(available, amountPerTick);
                if (apply <= FixedPoint2.Zero)
                {
                    continue;
                }

                toReapply.DamageDict[type] = memComp.Memory[type];
            }

            // If there's nothing to reapply, skip.
            if (toReapply.Empty)
            {
                memComp.NextReapply = now + TimeSpan.FromSeconds(memComp.ReapplyInterval);
                continue;
            }

            // Clear the memory when post-healing, and then skip reapplication.
            if (memComp.MemoryClear == true)
            {
                memComp.Memory.Clear();
                memComp.MemoryClear = false;
                memComp.NextReapply = TimeSpan.Zero;
                return;
            }

            // Reapply as positive damage.
            _damageable.TryChangeDamage(uid, toReapply, ignoreResistances: false, interruptsDoAfters: false, damageable: dmgComp);

            memComp.NextReapply = now + TimeSpan.FromSeconds(memComp.ReapplyInterval);
        }
    }
}
