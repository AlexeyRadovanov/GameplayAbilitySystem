using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private EnemyUI enemyUI;
    private EnemyStats stats;

    public void Initialize()
    {
        stats = new EnemyStats(startHealth);
        enemyUI.Initialize(stats);

        stats.OnDied += HandleDeath;
    }

    private void HandleDeath()
    {
        Destroy(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        stats.TakeDamage(damage);
    }
}