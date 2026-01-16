using System.Collections.Generic;
using UnityEngine;

public class AbilityBarUI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject prefabAbilityButton;

    public void Initialize(AbilityManager abilityManager, PlayerController playerController)
    {
        List<AbilityData> abilities = abilityManager.GetListAbilityData();

        for (int i = 0; i < abilities.Count; i++)
        {
            GameObject button = Instantiate(prefabAbilityButton, this.gameObject.transform);
            var buttonUI = button.GetComponent<AbilityButtonUI>();
            buttonUI.Initialize(i, abilityManager, playerController.GetTargetPosition);
        }
    }
}
