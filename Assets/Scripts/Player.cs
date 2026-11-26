using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask CountersLayerMask;
    private Vector3 inputDir;
    private Vector3 lastInteractionDir;
    private Vector3 moveDirX => new Vector3(inputDir.x,0,0).normalized;
    private Vector3 moveDirZ => new Vector3(0,0,inputDir.z).normalized; 
    private bool isWalking => inputDir != Vector3.zero; public bool IsWalking => isWalking;
    private float moveDistance => moveSpeed * Time.deltaTime;
    private float radius = .7f;
    private float height = 2f;
    private float interactionDistance = 2f;
    
    private void Start()
    {
        gameInput.OnInteraction += GameInput_OnInteraction; 
    }

    private void GameInput_OnInteraction(object sender, EventArgs e)
    {
        if(inputDir != Vector3.zero)
            lastInteractionDir = inputDir;


        if(Physics.Raycast(transform.position, lastInteractionDir , out RaycastHit raycastHit, interactionDistance, CountersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
                clearCounter.Interact();
        }
        else
            Debug.Log("-");
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        inputDir = gameInput.GetMovementVectorNormalized();

        if(CanMove(inputDir))
            transform.position += inputDir  * moveDistance;
        else
        {
            if(CanMove(moveDirX))
                transform.position += moveDirX  * moveDistance;
            else if(CanMove(moveDirZ))
                transform.position += moveDirZ  * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, inputDir,  rotationSpeed * Time.deltaTime);
    }

    private bool CanMove(Vector3 diraction) => !Physics.CapsuleCast(transform.position, transform.position + (Vector3.up * height), radius, diraction, moveDistance);
}
