using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "ScriptableObjects/AbilityData")]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    public float cooldown;
    public float cost;
    public Sprite icon;
    public List<AbilityEffectData> effects;
}
