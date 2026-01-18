using UnityEngine;

public class AbilityGizmoVisualizer : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private Color color;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = color;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }
}
