using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public event Action OnAttackPressed;
    public Vector2 MoveInput { get; private set; }

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

    private void Update()
    {
        MoveInput = ReadMoveInput();
    }

    private void HandleAttackPerformed(InputAction.CallbackContext context)
    {
        OnAttackPressed?.Invoke();
    }

    private Vector2 ReadMoveInput()
    {
        Vector2 move = inputActions.Player.Movement.ReadValue<Vector2>();

        return move.normalized;
    }
}
