// SPDX-FileCopyrightText: 2025 VMSolidus <evilexecutive@gmail.com>
// SPDX-FileCopyrightText: 2025 corresp0nd <46357632+corresp0nd@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 taydeo <td12233a@gmail.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later AND MIT

using Content.Shared._EE.Supermatter.Components;
using Content.Shared.Atmos;
using Robust.Shared.Configuration;

namespace Content.Shared._EE.CCVar;

[CVarDefs]
public sealed partial class ECCVars
{
    public static readonly CVarDef<float> SupermatterSingulooseMolesModifier =
        CVarDef.Create("supermatter.singuloose_moles_modifier", 1f, CVar.SERVER);

    public static readonly CVarDef<bool> SupermatterDoSingulooseDelam =
        CVarDef.Create("supermatter.do_singuloose", true, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterTesloosePowerModifier =
        CVarDef.Create("supermatter.tesloose_power_modifier", 1f, CVar.SERVER);

    public static readonly CVarDef<bool> SupermatterDoTeslooseDelam =
        CVarDef.Create("supermatter.do_tesloose", true, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterPowerPenaltyThreshold =
        CVarDef.Create("supermatter.power_penalty_threshold", 5000f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterSeverePowerPenaltyThreshold =
        CVarDef.Create("supermatter.power_penalty_threshold_severe", 7000f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterCriticalPowerPenaltyThreshold =
        CVarDef.Create("supermatter.power_penalty_threshold_critical", 9000f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterAmmoniaConsumptionPressure =
        CVarDef.Create("supermatter.ammonia_consumption_pressure", Atmospherics.OneAtmosphere * 0.01f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterAmmoniaPressureScaling =
        CVarDef.Create("supermatter.ammonia_pressure_scaling", Atmospherics.OneAtmosphere * 0.05f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterAmmoniaGasMixScaling =
        CVarDef.Create("supermatter.ammonia_gas_mix_scaling", 0.3f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterAmmoniaPowerGain =
        CVarDef.Create("supermatter.ammonia_power_gain", 10f, CVar.SERVER);

    public static readonly CVarDef<bool> SupermatterDoForceDelam =
        CVarDef.Create("supermatter.do_force_delam", false, CVar.SERVER);

    public static readonly CVarDef<DelamType> SupermatterForcedDelamType =
        CVarDef.Create("supermatter.forced_delam_type", DelamType.Singulo, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterHeatPenaltyThreshold =
        CVarDef.Create("supermatter.heat_penalty_threshold", 40f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterMatterPowerConversion =
        CVarDef.Create("supermatter.matter_power_conversion", 10f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterMoleHeatPenalty =
        CVarDef.Create("supermatter.mole_heat_penalty", 350f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterMolePenaltyThreshold =
        CVarDef.Create("supermatter.mole_penalty_threshold", 1800f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterOxygenReleaseModifier =
        CVarDef.Create("supermatter.oxygen_release_modifier", 325f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterPlasmaReleaseModifier =
        CVarDef.Create("supermatter.plasma_release_modifier", 750f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterPowerlossInhibitionGasThreshold =
        CVarDef.Create("supermatter.powerloss_inhibition_gas_threshold", 0.2f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterPowerlossInhibitionMoleThreshold =
        CVarDef.Create("supermatter.powerloss_inhibition_mole_threshold", 20f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterPowerlossInhibitionMoleBoostThreshold =
        CVarDef.Create("supermatter.powerloss_inhibition_mole_boost_threshold", 500f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterRadsBase =
        CVarDef.Create("supermatter.rads_base", 3f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterRadsModifier =
        CVarDef.Create("supermatter.rads_modifier", 1f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterReactionPowerModifier =
        CVarDef.Create("supermatter.reaction_power_modifier", 0.55f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterThermalReleaseModifier =
        CVarDef.Create("supermatter.thermal_release_modifier", 5f, CVar.SERVER);

    public static readonly CVarDef<float> SupermatterYellTimer =
        CVarDef.Create("supermatter.yell_timer", 60f, CVar.SERVER);
}
