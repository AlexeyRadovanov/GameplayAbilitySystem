using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerController player;

    private void Start()
    {
        player.Initialize();
    }
}
