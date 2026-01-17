using UnityEngine;

[CreateAssetMenu(fileName = "Damage Over Time", menuName = "ScriptableObjects/Effects/Damage Over Time")]
public class DamageOverTimeEffect : AbilityEffectData
{
    public float tickDamage;
    public float duration;
    public float tickInterval;

    public override void Apply(AbilityContext context)
    {
        context.Target.GetComponent<IDamageable>()?.ApplyDamageOverTime(tickDamage, duration, tickInterval);
    }
}