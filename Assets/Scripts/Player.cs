using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking; public bool IsWalking => isWalking;
    
    private void Update()
    {
        Vector3 input = gameInput.GetMovementVectorNormalized();
        
        isWalking = input != Vector3.zero;

        transform.position += input  * moveSpeed * Time.deltaTime;

        transform.forward = Vector3.Slerp(transform.forward, input,  rotationSpeed * Time.deltaTime);
    }
}
