using UnityEngine;

public class PlayerDebugUI : MonoBehaviour
{
    private PlayerStats stats;

    public void Initialize(PlayerStats stats)
    {
        this.stats = stats;
    }

    private void OnGUI()
    {
        if (!Debug.isDebugBuild) return;

        GUILayout.Label($"HP: {stats.Health}/{stats.HealthMax}");
        GUILayout.Label($"Energy: {stats.Energy}");
    }  
}