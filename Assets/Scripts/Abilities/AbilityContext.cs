using UnityEngine;

public class AbilityContext
{
    public Transform Caster;
    public Vector3 TargetPosition;
    public PlayerStats Stats;

    public AbilityContext(Transform caster, Vector3 targetPosition, PlayerStats stats)
    {
        Caster = caster;
        TargetPosition = targetPosition;
        Stats = stats;
    }
}
