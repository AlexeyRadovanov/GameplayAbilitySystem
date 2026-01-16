public class AbilityInstance
{
    public AbilityData Data;
    public float cooldownTimer;

    public AbilityInstance(AbilityData data)
    {
        Data = data;
    }

    public void Activate(AbilityContext context)
    {
        cooldownTimer = Data.cooldown;

        foreach (var effect in Data.effects)
        {
            effect.Apply(context);
        }
    }

    public bool CanActivate(PlayerStats stats)
    {
        return cooldownTimer <= 0 && stats.HasEnough(Data.cooldown);
    }

    public void Tick(float deltaTime)
    {
        if (cooldownTimer > 0f)
            cooldownTimer -= deltaTime;
    }
}
