using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, IHealth
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

    public void ApplyDamage(float amount)
    {
        stats.ApplyDamage(amount);

        FloatingTextSpawner.Instance?.Spawn(
            $"-{amount}",
            Color.red,
            this.transform.position
        );
    }

    public void ApplyDamageOverTime(float amount, float duration, float tickInterval)
    {
        if (DamageOverTimeCoroutine != null)
            StopCoroutine(DamageOverTimeCoroutine);

        DamageOverTimeCoroutine = StartCoroutine(DamageOverTimeRoutine(amount, duration, tickInterval));
    }

    private IEnumerator DamageOverTimeRoutine(float amount, float duration, float tickInterval)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            stats.ApplyDamage(amount);

            FloatingTextSpawner.Instance?.Spawn(
                $"-{amount}",
                Color.red,
                this.transform.position
            );

            yield return new WaitForSeconds(tickInterval);
            elapsedTime += tickInterval;
        }
    }

    public void ApplyHeal(float amount)
    {
        stats.ApplyHeal(amount);

        FloatingTextSpawner.Instance?.Spawn(
            $"+{amount}",
            Color.green,
            this.transform.position
        );
    }
}