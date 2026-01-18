using UnityEngine;

[CreateAssetMenu(fileName = "Damage Over Time", menuName = "ScriptableObjects/Effects/Damage Over Time")]
public class DamageOverTimeEffect : AbilityEffectData
{
    public float amount;
    public float duration;
    public float tickInterval;

    public override void Apply(AbilityContext context)
    {
        context.Target.GetComponent<IHealth>()?.ApplyDamageOverTime(amount, duration, tickInterval);
    }
}