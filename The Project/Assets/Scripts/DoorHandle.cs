using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    public Animator doorAnimator; // Optional: link an Animator
    public bool useAnimation = true;

    public void Unlock()
    {
        if (useAnimation && doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
        else
        {
            // Simple alternative: disable collider or rotate open
            Debug.Log("Door unlocked – no animation used.");
            transform.Rotate(0, 90f, 0); // Rotate door open
        }
    }
}
