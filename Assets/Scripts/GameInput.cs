using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions  inputActions;

    private void Awake()
    {
        inputActions = new();
        inputActions.Enable();
    }
    public Vector3 GetMovementVectorNormalized()
    {
        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();

        return new Vector3(input.x,0f,input.y).normalized;
    }
}
