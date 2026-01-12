using UnityEngine;

public class SpawnProjectileEffect : AbilityEffectData
{
    [SerializeField] private GameObject prefab;

    public override void Apply(AbilityContext context)
    {
        Vector3 targetDirection = (context.TargetPosition - context.Caster.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        GameObject projectileObject = Instantiate(prefab, context.Caster.position, targetRotation);
        var projectile = projectileObject.GetComponent<Projectile>();
        projectile.Initialize(context);
    }
}