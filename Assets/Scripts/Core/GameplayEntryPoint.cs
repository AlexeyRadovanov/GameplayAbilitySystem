using System.Collections.Generic;
using UnityEngine;

// EntryPoint specifies the order of initialization of systems
public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private AbilityManager abilityManager;
    [SerializeField] private PlayerUI playerUI;

    [SerializeField] private List<Enemy> enemies;

    private void Start()
    {
        player.Initialize();

        foreach (Enemy enemy in enemies)
        {
            enemy.Initialize();
        }

        abilityManager.Initialize(player);
        playerUI.Initialize(abilityManager, player);
    }
}
