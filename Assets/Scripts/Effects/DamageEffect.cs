using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "ScriptableObjects/Effects/Damage")]
public class DamageEffect : AbilityEffectData
{
    public float damage;

    public override void Apply(AbilityContext context)
    {
        context.Target.GetComponent<IDamageable>()?.TakeDamage(damage);
    }
}