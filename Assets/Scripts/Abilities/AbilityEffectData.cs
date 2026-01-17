using UnityEngine;

// Effects must be stateless: no runtime data here
public abstract class AbilityEffectData : ScriptableObject
{
    public abstract void Apply(AbilityContext context);
}
