using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private AbilityManager abilityManager;
    private PlayerInputActions input;

    private void Awake()
    {
        abilityManager = GetComponent<AbilityManager>();
        if (abilityManager == null) Debug.LogError("Ability Manager not found");
        input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        input.Gameplay.Enable();
        input.Gameplay.PrimaryAbility.performed += OnPrimaryAbility;
    }

    private void OnDisable()
    {
        input.Gameplay.PrimaryAbility.performed -= OnPrimaryAbility;
        input.Gameplay.Disable();
    }

    private void OnPrimaryAbility(InputAction.CallbackContext context)
    {
        abilityManager.TryActivate(0, GetTargetPosition());
    }

    private Vector3 GetTargetPosition()
    {
        Vector3 targetPosition = new Vector3();



        return targetPosition;
    }
}
