using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteraction;
    private PlayerInputActions  inputActions;

    private void Awake()
    {
        inputActions = new();
        inputActions.Enable();

        inputActions.Player.Interact.performed += Interact_Performed; 
    }

    private void Interact_Performed(InputAction.CallbackContext context)
    {
        OnInteraction?.Invoke(this, EventArgs.Empty);
    }

    public Vector3 GetMovementVectorNormalized()
    {
        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();

        return new Vector3(input.x,0f,input.y).normalized;
    }
}
