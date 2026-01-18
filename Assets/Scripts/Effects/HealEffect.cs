using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "ScriptableObjects/Effects/Heal")]
public class HealEffect : AbilityEffectData
{
    public float amount;

    public override void Apply(AbilityContext context)
    {
        context.CasterController.GetComponent<IHealth>()?.ApplyHeal(amount);
    }
}