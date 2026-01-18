using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private AbilityManager abilityManager;
    private PlayerController playerController;
    private PlayerInputActions input;
    private Vector2 moveInput;

    private void Awake()
    {
        abilityManager = GetComponent<AbilityManager>();
        if (abilityManager == null) GameDebug.Log("Ability Manager not found", this);

        playerController = GetComponent<PlayerController>();
        if (playerController == null) GameDebug.Log("Player Controller not found", this);

        input = new PlayerInputActions();
    }

    private void OnEnable()
    {
        input.Gameplay.Enable();
        input.Gameplay.Move.performed += OnMove;
        input.Gameplay.Move.canceled += OnMove;
        input.Gameplay.Ability1.performed += OnAbility1;
        input.Gameplay.Ability2.performed += OnAbility2;
        input.Gameplay.Ability3.performed += OnAbility3;
        input.Gameplay.Ability4.performed += OnAbility4;
        input.Gameplay.Ability5.performed += OnAbility5;
    }

    private void OnDisable()
    {
        input.Gameplay.Move.performed -= OnMove;
        input.Gameplay.Move.canceled -= OnMove;
        input.Gameplay.Ability1.performed -= OnAbility1;
        input.Gameplay.Ability2.performed -= OnAbility2;
        input.Gameplay.Ability3.performed -= OnAbility3;
        input.Gameplay.Ability4.performed -= OnAbility4;
        input.Gameplay.Ability5.performed -= OnAbility5;
        input.Gameplay.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnAbility1(InputAction.CallbackContext context)
    {
        abilityManager.TryActivate(0, playerController.GetTargetPosition());
    }

    private void OnAbility2(InputAction.CallbackContext context)
    {
        abilityManager.TryActivate(1, playerController.GetTargetPosition());
    }

    private void OnAbility3(InputAction.CallbackContext context)
    {
        abilityManager.TryActivate(2, playerController.GetTargetPosition());
    }

    private void OnAbility4(InputAction.CallbackContext context)
    {
        abilityManager.TryActivate(3, playerController.GetTargetPosition());
    }

    private void OnAbility5(InputAction.CallbackContext context)
    {
        abilityManager.TryActivate(4, playerController.GetTargetPosition());
    }

    private void Update()
    {
        playerController.Move(moveInput);
    }
}
