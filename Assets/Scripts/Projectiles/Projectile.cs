using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    private float lifetime;

    public void Initialize(ProjectileData  projectileData, AbilityContext context)
    {
        this.damage = projectileData.damage;
        this.lifetime = projectileData.lifetime;

        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 targetDirection = (context.TargetPosition - context.Caster.position).normalized;
        rb.linearVelocity = targetDirection * projectileData.speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0) Destroy(this.gameObject);
    }
}
