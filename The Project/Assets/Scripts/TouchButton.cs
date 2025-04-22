using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    public int buttonNumber; // Assign in Inspector
    public Material hoverMaterial;
    private Material originalMaterial;
    private Renderer rend;
    private NumberPad numberPad;

    protected override void Awake()
    {
        base.Awake();
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;

        // Find NumberPad in scene
        numberPad = FindObjectOfType<NumberPad>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        rend.material = hoverMaterial;

        if (numberPad != null)
        {
            numberPad.ReceiveNumber(buttonNumber);
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        rend.material = originalMaterial;
    }
}
