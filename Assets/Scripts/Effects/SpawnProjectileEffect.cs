using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Projectile", menuName = "ScriptableObjects/Effects/Spawn Projectile")]
public class SpawnProjectileEffect : AbilityEffectData
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;

    public override void Apply(AbilityContext context)
    {
        Vector3 targetDirection = (context.TargetPosition - context.Caster.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        GameObject projectileObject = Instantiate(prefab, context.Caster.position, targetRotation);
        var projectile = projectileObject.GetComponent<Projectile>();

        ProjectileData projectileData = new (damage, speed, lifetime);
        projectile.Initialize(projectileData, context);
    }
}