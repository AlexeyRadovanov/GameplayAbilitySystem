using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private List<AbilityData> abilityDatas;

    private List<AbilityInstance> abilities;
    private PlayerStats stats;

    public void Initialize(PlayerStats stats)
    {
        this.stats = stats;

        abilities = new List<AbilityInstance> ();
        foreach (var data in abilityDatas)
        {
            abilities.Add(new AbilityInstance(data));
        }
    }

    public void TryActivate(int index, Vector3 targetPosition)
    {
        AbilityInstance ability = abilities[index];

        if (!ability.CanActivate(stats))
            return;

        if (!stats.HasEnough(ability.Data.cost))
            return;

        stats.ConsumeEnergy(ability.Data.cost);

        AbilityContext context = new AbilityContext(this.transform, targetPosition, stats);

        ability.Activate(context);
    }

    private void Update()
    {
        foreach (var ability in abilities)
        {
            ability.Tick(Time.deltaTime);
        }
    }
}
