public class ResourceSystem
{
    public float energy;

    public bool HasEnough(float cost)
    {
        return energy >= cost;
    }
}
