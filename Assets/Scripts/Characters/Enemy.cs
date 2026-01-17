using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float startHealth;
    [SerializeField] private EnemyUI enemyUI;
    private EnemyStats stats;
    private Coroutine DamageOverTimeCoroutine;

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

    public void TakeDamage(float amount)
    {
        stats.TakeDamage(amount);
    }

    public void ApplyDamageOverTime(float tickDamage, float duration, float tickInterval)
    {
        if (DamageOverTimeCoroutine != null)
            StopCoroutine(DamageOverTimeCoroutine);

        DamageOverTimeCoroutine = StartCoroutine(DamageOverTimeRoutine(tickDamage, duration, tickInterval));
    }

    private IEnumerator DamageOverTimeRoutine(float tickDamage, float duration, float tickInterval)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            stats.TakeDamage(tickDamage);
            yield return new WaitForSeconds(tickInterval);
            elapsedTime += tickInterval;
        }
    }
}