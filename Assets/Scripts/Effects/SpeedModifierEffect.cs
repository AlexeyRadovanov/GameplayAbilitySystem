using UnityEngine;

[CreateAssetMenu(fileName = "Speed Modifier", menuName = "ScriptableObjects/Effects/Speed Modifier")]
public class SpeedModifierEffect : AbilityEffectData
{
    public float speedMultiplier;
    public float duration;

    public override void Apply(AbilityContext context)
    {
        context.CasterController?.ApplySpeedModifier(speedMultiplier, duration);
    }
}
