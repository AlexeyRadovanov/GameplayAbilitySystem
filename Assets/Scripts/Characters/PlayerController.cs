using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

// Entry point for gameplay interactions affecting the player
// Doesn't store gameplay state
public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private float startHealth;
    [SerializeField] private float startEnergy;
    [SerializeField] private float startEnergyRegenerationRate;
    [SerializeField] private float startSpeed;

    private AbilityManager abilityManager;
    public PlayerStats stats;
    private Coroutine DamageOverTimeCoroutine;

    public void Initialize()
    {
        stats = new PlayerStats(startHealth, startEnergy, startEnergyRegenerationRate, startSpeed);

        abilityManager = GetComponent<AbilityManager>();
        if (abilityManager == null )  Debug.LogError("Ability Manager not found");
    }
    void Update()
    {
        stats.UpdateEnergy(Time.deltaTime);
    }

    public Vector3 GetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        Plane planeXZ = new Plane(Vector3.up, Vector3.zero);

        Vector3 targetPosition = new();

        if (planeXZ.Raycast(ray, out float distance))
            targetPosition = ray.GetPoint(distance);

        return targetPosition;
    }

    public void Move(Vector2 moveDirection)
    {
        Vector3 move = new Vector3(moveDirection.x, 0, moveDirection.y);
        transform.position += move * stats.Speed * Time.deltaTime;
    }

    public void TakeDamage(float amount)
    {
        stats.TakeDamage(amount);
    }

    public void ApplySpeedModifier(float modifier, float duration)
    {
        StartCoroutine(SpeedModifierRoutine(modifier, duration));
    }

    private IEnumerator SpeedModifierRoutine(float modifier, float duration)
    {
        stats.SetSpeedModifier(modifier);
        yield return new WaitForSeconds(duration);
        stats.SetSpeedModifier(1f);
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
