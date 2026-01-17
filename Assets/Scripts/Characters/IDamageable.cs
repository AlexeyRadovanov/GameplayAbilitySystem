public interface IDamageable
{
    void TakeDamage(float amount);
    void ApplyDamageOverTime(float tickDamage, float duration, float tickInterval);
}