public class AbilityInstance
{
    public AbilityData Data;
    private float cooldownTimer;

    public void Activate(AbilityContext context)
    {
        cooldownTimer = Data.cooldown;

        foreach (var effect in Data.effects)
        {
            effect.Apply(context);
        }
    }

    public bool CanActivate(ResourceSystem resources)
    {
        return cooldownTimer <= 0 && resources.HasEnough(Data.cost);
    }

}
