using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plasma Shot", menuName = "ScriptableObjects/Effects/Plasma Shot")]
public class PlasmaShotEffect : AbilityEffectData
{
    [SerializeField] private float range;
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private List<AbilityEffectData> onHitEffects;

    public override void Apply(AbilityContext context)
    {
        if (Physics.Raycast(
            context.Caster.position,
            context.Caster.forward,
            out RaycastHit hit,
            range,
            hitMask))
        {
            Debug.Log("hit - " + hit.collider.transform.name + ", range = " + hit.distance);
            var target = hit.transform;
            var hitContext = context.WithTarget(target);

            foreach (var effect in onHitEffects)
            {
                effect.Apply(hitContext);
            }
        }
        else Debug.Log("Missing fire");
    }
}
