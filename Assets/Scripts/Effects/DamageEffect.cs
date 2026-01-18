using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "ScriptableObjects/Effects/Damage")]
public class DamageEffect : AbilityEffectData
{
    public float amount;

    public override void Apply(AbilityContext context)
    {
        context.Target.GetComponent<IHealth>()?.ApplyDamage(amount);
    }
}