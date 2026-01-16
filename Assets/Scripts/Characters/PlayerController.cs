using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private float startEnergy;
    [SerializeField] private float startEnergyRegenerationRate;
    [SerializeField] private float startSpeed;

    private AbilityManager abilityManager;
    public PlayerStats stats;

    public void Initialize()
    {
        stats = new PlayerStats(startHealth, startEnergy, startEnergyRegenerationRate, startSpeed);

        abilityManager = GetComponent<AbilityManager>();
        if (abilityManager == null )  Debug.LogError("Ability Manager not found");
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

    public void TakeDamage(float damage)
    {
        stats.TakeDamage(damage);
    }
}
