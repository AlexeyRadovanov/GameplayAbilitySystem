using UnityEngine;

public class ApplyStatusEffect : AbilityEffectData
{
    [SerializeField] private GameObject prefab;

    public override void Apply(AbilityContext context)
    {
        Instantiate(prefab, context.TargetPosition, Quaternion.identity);
    }
}