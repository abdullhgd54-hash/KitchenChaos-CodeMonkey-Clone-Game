using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 15f;
    private bool isWalking; public bool IsWalking => isWalking;
    
    private void Update()
    {
        Vector3 input = Vector3.zero;

        if(Input.GetKey(KeyCode.W))
            input.z = 1;
            
        if(Input.GetKey(KeyCode.S))
            input.z = -1;
            
        if(Input.GetKey(KeyCode.D))
            input.x = 1;

        if(Input.GetKey(KeyCode.A))
            input.x = -1;

        input = input.normalized;

        isWalking = input != Vector3.zero;

        transform.position += input  * moveSpeed * Time.deltaTime;

        transform.forward = Vector3.Slerp(transform.forward, input,  rotationSpeed * Time.deltaTime);
    }
}
