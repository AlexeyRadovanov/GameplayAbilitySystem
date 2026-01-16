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

    public void TakeDamage(float damage)
    {
        Health -= damage;
        OnHealthChanged?.Invoke(Health, HealthMax);

        if (Health <= 0)
        {
            OnDied?.Invoke();
            return;
        }
    }
}
