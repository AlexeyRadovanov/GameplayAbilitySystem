using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private List<AbilityData> abilityDatas;

    private List<AbilityInstance> abilities;
    private PlayerStats playerStats;
    private PlayerController playerController;
    private bool isInitialized;

    public event Action<int> OnAbilityActivated;

    public void Initialize(PlayerController playerController)
    {
        this.playerStats = playerController.stats;
        this.playerController = playerController;

        abilities = new List<AbilityInstance>();
        foreach (var data in abilityDatas)
        {
            abilities.Add(new AbilityInstance(data));
        }

        isInitialized = true;
    }

    public void TryActivate(int index, Vector3 targetPosition)
    {
        Debug.Log($"TryActivate called with index {index}");

        if (!isInitialized)
        {
            Debug.LogError("AbilityManager is not initialized");
            return;
        }

        if (index < 0 || index >= abilities.Count)
        {
            Debug.LogError($"Invalid ability index {index}");
            return;
        }

        AbilityInstance ability = abilities[index];

        if (!ability.CanActivate(playerStats))
            return;

        if (!playerStats.HasEnough(ability.Data.cost))
            return;

        playerStats.ConsumeEnergy(ability.Data.cost);

        AbilityContext context = new AbilityContext(
            this.transform,
            playerStats,
            playerController,
            targetPosition);
        Debug.Log($"Ability count: {abilities.Count}");
        Debug.Log($"Cooldown remaining: {GetCooldownRemaining(index)}");
        Debug.Log($"Energy: {playerStats.Energy}");

        ability.Activate(context);

        OnAbilityActivated(index);
    }

    private void Update()
    {
        foreach (var ability in abilities)
        {
            ability.Tick(Time.deltaTime);
        }
    }

    public List<AbilityData> GetListAbilityData()
    {
        return abilityDatas;
    }

    public float GetCooldownRemaining(int i)
    {
        if (!isInitialized)
        {
            Debug.LogError("AbilityManager is not initialized");
            return 0f;
        }

        return abilities[i].cooldownTimer;
    }

    public float GetCooldownDuration(int i)
    {
        if (!isInitialized)
        {
            Debug.LogError("AbilityManager is not initialized");
            return 0f;
        }

        return abilities[i].Data.cooldown;
    }

    public Sprite GetAbilityIcon(int i)
    {
        if (!isInitialized)
        {
            Debug.LogError("AbilityManager is not initialized");
            return null;
        }

        return abilities[i].Data.icon;
    }
}
