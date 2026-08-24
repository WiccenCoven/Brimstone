using Content.Shared.Damage.Prototypes;
using Content.Shared.FixedPoint;
using Robust.Shared.GameStates;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;

namespace Content.Server._Brimstone.HareMed.DamageMemory;

[RegisterComponent, NetworkedComponent]
public sealed partial class WicceDamageMemoryComponent : Component
{
    /// <summary>
    /// Amount of healed damage to remember per damage type
    /// Keys are ProtoId<DamageTypePrototype> (same as DamageSpecifier keys)
    /// </summary>
    [DataField("memory"), ViewVariables(VVAccess.ReadWrite)]
    public Dictionary<ProtoId<Content.Shared.Damage.Prototypes.DamageTypePrototype>, FixedPoint2> Memory =
        new();

    /// <summary>
    // Max memory per damage type. If zero, no cap.
    /// </summary>
    [DataField("maxMemoryPerType"), ViewVariables(VVAccess.ReadWrite)]
    public FixedPoint2 MaxMemoryPerType = FixedPoint2.Zero;

    /// <summary>
    // Global cap across all damage types. If zero, no cap.
    /// </summary>
    [DataField("globalMemoryCap"), ViewVariables(VVAccess.ReadWrite)]
    public FixedPoint2 GlobalMemoryCap = FixedPoint2.Zero;

    /// <summary>
    /// Damage groups that should be ignored by the memory tracker.
    /// </summary>
    [DataField("disallowedDamageGroups"), ViewVariables(VVAccess.ReadWrite)]
    public HashSet<ProtoId<DamageGroupPrototype>> DisallowedDamageTypes = new();

    /// <summary>
    // How much remembered damage is reapplied per ReapplyInterval (absolute).
    /// </summary>
    [DataField("reapplyPerSecond"), ViewVariables(VVAccess.ReadWrite)]
    public FixedPoint2 ReapplyPerSecond = FixedPoint2.New(1);

    /// <summary>
    // How often (seconds) to tick the reapplication. Defaulted to 5 to give you time to actually post heal.
    /// </summary>
    [DataField("reapplyInterval"), ViewVariables(VVAccess.ReadWrite)]
    public float ReapplyInterval = 2f;

    /// <summary>
    // Next time to attempt reapply
    /// </summary>
    [DataField("nextReapply", customTypeSerializer: typeof(TimeOffsetSerializer)), ViewVariables(VVAccess.ReadWrite)]
    public TimeSpan NextReapply = TimeSpan.Zero;

    /// <summary>
    // Clear the memory? For post heals.
    /// </summary>
    [DataField("memoryClear"), ViewVariables(VVAccess.ReadWrite)]
    public bool MemoryClear = false;
}
