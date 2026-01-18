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
        Vector3 targetDirection = (context.TargetPosition - context.Caster.position).normalized;

        if (Physics.Raycast(
            context.Caster.position,
            targetDirection,
            out RaycastHit hit,
            range,
            hitMask))
        {
            GameDebug.Log("hit - " + hit.collider.transform.name + ", range = " + hit.distance, this);
            var target = hit.transform;
            var hitContext = context.WithTarget(target);

            foreach (var effect in onHitEffects)
            {
                effect.Apply(hitContext);
            }
        }
        else GameDebug.Log("Missing fire", this);

        Debug.DrawRay(context.Caster.position, targetDirection * range, Color.yellow, 0.5f);

    }
}
