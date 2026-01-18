using System;
using UnityEngine;

public class PlayerStats
{
    public float Health;
    public float HealthMax;
    public float Energy;
    public float EnergyMax;
    public float EnergyRegenerationRate;
    public float BaseSpeed;
    public float SpeedModifier = 1f;
    public float Speed => BaseSpeed * SpeedModifier;

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
        BaseSpeed = speed;
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

    public void UpdateEnergy(float deltaTime)
    {
        Energy = Mathf.Min(EnergyMax, Energy + EnergyRegenerationRate * deltaTime);

        OnEnergyChanged?.Invoke(Energy, EnergyMax);
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        OnHealthChanged?.Invoke(Health, HealthMax);

        if (Health <= 0)
        {
            OnDied?.Invoke();
            return;
        }
    }

    public void Heal(float amount)
    {
        Health = Math.Min(Health + amount, HealthMax);

        OnHealthChanged?.Invoke(Health, HealthMax);
    }

    public void SetSpeedModifier(float modifier)
    {
        SpeedModifier = modifier;
    }
}
