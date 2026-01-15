public class PlayerStats
{
    public float Health;
    public float Energy;
    public float EnergyRegenerationRate;

    public bool HasEnough(float cost)
    {
        return Energy >= cost;
    }

    public void ConsumeEnergy(float cost)
    {
        Energy -= cost;
    }
}
