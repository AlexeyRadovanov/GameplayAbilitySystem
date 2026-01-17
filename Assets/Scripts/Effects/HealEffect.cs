using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "ScriptableObjects/Effects/Heal")]
public class HealEffect : AbilityEffectData
{
    public float healAmount;

    public override void Apply(AbilityContext context)
    {
        context.PlayerStats.Heal(healAmount);
    }
}