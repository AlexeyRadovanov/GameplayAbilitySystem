using UnityEngine;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] private FillBarUI healthBar;

    private EnemyStats stats;

    public void Initialize(EnemyStats stats)
    {
        this.stats = stats;

        stats.OnHealthChanged += UpdateHealth;
        UpdateHealth(stats.Health, stats.HealthMax);
    }

    private void OnDestroy()
    {
        stats.OnHealthChanged -= UpdateHealth;
    }

    private void UpdateHealth(float current, float max)
    {
        healthBar.SetValue(current, max);
    }
}
