using UnityEngine;

public class Projectile : MonoBehaviour
{
    private AbilityContext context;

    public void Initialize(AbilityContext context)
    {
        this.context = context;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
