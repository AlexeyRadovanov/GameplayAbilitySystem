using System.Collections.Generic;
using UnityEngine;

// Projectile is a delivery object for effects
// It does decide what happens on hit
public class Projectile : MonoBehaviour
{
    private float lifetime;
    private AbilityContext context;
    private List<AbilityEffectData> onHitEffects;

    public void Initialize(ProjectileData  projectileData, AbilityContext context, List<AbilityEffectData> onHitEffects)
    {
        this.lifetime = projectileData.lifetime;
        this.context = context;
        this.onHitEffects = onHitEffects;

        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 targetDirection = (context.TargetPosition - context.Caster.position).normalized;
        rb.linearVelocity = targetDirection * projectileData.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IDamageable>(out var target))
            return;

        AbilityContext hitContext = context.WithTarget(other.transform);

        foreach (var effect in onHitEffects)
        {
            effect.Apply(hitContext);
        }

        Destroy(this.gameObject);
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0) Destroy(this.gameObject);
    }
}
