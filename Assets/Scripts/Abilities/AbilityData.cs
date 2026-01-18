using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "ScriptableObjects/AbilityData")]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    [Tooltip("Time in seconds before ability can be used again")]
    public float cooldown;
    [Tooltip("Cost in energy units for activation")]
    public float cost;
    public Sprite icon;
    public List<AbilityEffectData> effects;

    private void OnValidate()
    {
        cooldown = Mathf.Max(0f, cooldown);
        cost = Mathf.Max(0f, cost);
    }
}