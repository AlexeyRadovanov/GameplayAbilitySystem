using System;

public class EnemyStats
{
    public float Health;
    public float HealthMax;
    
    public event Action<float, float> OnHealthChanged;
    public event Action OnDied;

    public EnemyStats(float health)
    {
        Health = health;
        HealthMax = health;
    }

    public void ApplyDamage(float amount)
    {
        Health -= amount;
        OnHealthChanged?.Invoke(Health, HealthMax);

        if (Health <= 0)
        {
            OnDied?.Invoke();
            return;
        }
    }

    public void ApplyHeal(float amount)
    {
        Health = Math.Min(Health + amount, HealthMax);

        OnHealthChanged?.Invoke(Health, HealthMax);
    }
}
