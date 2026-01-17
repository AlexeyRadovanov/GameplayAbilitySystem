using UnityEngine;

public class AbilityContext
{
    public Transform Caster { get; }
    public PlayerStats PlayerStats { get; }
    public PlayerController CasterController { get; }
    public Vector3 TargetPosition { get; }
    public Transform Target { get; }


    public AbilityContext(
        Transform caster,
        PlayerStats playerStats,
        PlayerController casterController,
        Vector3 targetPosition,
        Transform target = null)
    {
        Caster = caster;
        PlayerStats = playerStats;
        CasterController = casterController;
        TargetPosition = targetPosition;
        Target = target;
    }

    public AbilityContext WithTarget(Transform target)
    {
        return new AbilityContext(Caster, PlayerStats, CasterController, TargetPosition, target);
    }
}
