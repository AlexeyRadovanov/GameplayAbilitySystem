using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private FillBarUI healthBar;
    [SerializeField] private FillBarUI energyBar;
    [SerializeField] private AbilityBarUI abilityBar;

    private PlayerStats stats;

    public void Initialize(AbilityManager abilityManager, PlayerController player)
    {
        stats = player.stats;

        UpdateHealth(stats.Health, stats.HealthMax);
        UpdateEnergy(stats.Energy, stats.EnergyMax);

        stats.OnHealthChanged += UpdateHealth;
        stats.OnEnergyChanged += UpdateEnergy;

        abilityBar.Initialize(abilityManager, player);
    }

    private void OnDestroy()
    {
        stats.OnHealthChanged -= UpdateHealth;
        stats.OnEnergyChanged -= UpdateEnergy;
    }

    private void UpdateHealth(float current, float max)
    {
        healthBar.SetValue(current, max);
    }

    private void UpdateEnergy(float current, float max)
    {
        energyBar.SetValue(current, max);
    }
}
