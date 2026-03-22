using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action OnAttackPressed;

    private InputSystem inputActions;

    private void Awake()
    {
        inputActions = new InputSystem();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Attack.performed += HandleAttackPerformed;
    }

    private void OnDisable()
    {
        inputActions.Player.Attack.performed -= HandleAttackPerformed;
        inputActions.Disable();
    }

    private void HandleAttackPerformed(InputAction.CallbackContext context)
    {
        OnAttackPressed?.Invoke();
    }
}