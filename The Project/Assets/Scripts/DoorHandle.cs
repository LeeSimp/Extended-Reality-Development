using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    public Transform doorTransform;   
    public float maxDragDistance = 0.35f;    
    public float doorWeight = 5f;             
    public bool isUnlocked = false;

    [Tooltip("The direction the door slides in local space. E.g. (1, 0, 0) for right, (0, 1, 0) for up.")]
    public Vector3 localMoveDirection = Vector3.left;
    private Vector3 worldMoveDirection;              

    private Vector3 doorStartPosition;
    private Vector3 doorEndPosition;

    private IXRSelectInteractor grabbingInteractor;

    private void Start()
    {
        // Convert local direction to world direction
        worldMoveDirection = doorTransform.TransformDirection(localMoveDirection.normalized);

        // Set start and end positions
        doorStartPosition = doorTransform.position;
        doorEndPosition = doorStartPosition + worldMoveDirection * maxDragDistance;
    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        grabbingInteractor = args.interactorObject;
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        grabbingInteractor = null;
    }

    void Update()
    {
        if (!isUnlocked || grabbingInteractor == null) return;

        // Pull vector from handle to hand
        Vector3 handPosition = grabbingInteractor.transform.position;
        Vector3 handlePosition = transform.position;
        Vector3 pullVector = handPosition - handlePosition;

        // Dot product to check pull alignment with door direction
        float alignment = Vector3.Dot(pullVector.normalized, worldMoveDirection);

        // Only allow if pulling mostly in the correct direction
        if (alignment > 0.5f)
        {
            // Pull strength (projected pull length in direction of door movement)
            float pullAmount = Vector3.Dot(pullVector, worldMoveDirection);

            // Speed based on pullAmount and door weight
            float speed = Mathf.Abs(pullAmount) / Time.deltaTime / doorWeight;

            // Move door along move direction
            Vector3 newPosition = doorTransform.position + worldMoveDirection * speed * Time.deltaTime;

            // Clamp between start and end positions
            float slideAmount = Vector3.Dot(newPosition - doorStartPosition, worldMoveDirection);
            slideAmount = Mathf.Clamp(slideAmount, 0f, maxDragDistance);
            doorTransform.position = doorStartPosition + worldMoveDirection * slideAmount;
        }
    }

    // Optional: call this from NumberPad when code is correct
    public void UnlockDoor()
    {
        isUnlocked = true;
    }
}
