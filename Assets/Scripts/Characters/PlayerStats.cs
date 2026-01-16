using System;
using UnityEngine;

public class PlayerStats
{
    public float Health;
    public float HealthMax;
    public float Energy;
    public float EnergyMax;
    public float EnergyRegenerationRate;
    public float Speed;

    public event Action<float, float> OnEnergyChanged;
    public event Action<float, float> OnHealthChanged;
    public event Action OnDied;

    public PlayerStats(float health, float energy, float energyRegenerationRate, float speed)
    {
        Health = health;
        HealthMax = health;
        Energy = energy;
        EnergyMax = energy;
        EnergyRegenerationRate = energyRegenerationRate;
        Speed = speed;
    }

    public bool HasEnough(float cost)
    {
        return Energy >= cost;
    }

    public void ConsumeEnergy(float cost)
    {
        Energy -= cost;

        OnEnergyChanged?.Invoke(Energy, EnergyMax);
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
