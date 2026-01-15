using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private AbilityManager abilityManager;
    private PlayerStats stats;

    public void Initialize()
    {
        stats = new PlayerStats();

        abilityManager = GetComponent<AbilityManager>();
        if (abilityManager == null )  Debug.LogError("Ability Manager not found");

        abilityManager.Initialize(stats);
    }
}
