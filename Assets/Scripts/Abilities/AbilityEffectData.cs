using UnityEngine;

public abstract class AbilityEffectData : ScriptableObject
{
    public abstract void Apply(AbilityContext context);
}
