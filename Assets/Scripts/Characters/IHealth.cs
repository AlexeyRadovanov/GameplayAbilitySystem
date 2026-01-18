public interface IHealth
{
    void ApplyDamage(float amount);
    void ApplyDamageOverTime(float tickDamage, float duration, float tickInterval);
    void ApplyHeal(float amount);
}