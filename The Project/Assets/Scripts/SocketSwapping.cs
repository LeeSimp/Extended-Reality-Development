using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSwapping : XRSocketInteractor
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        // Check if the socket already has a selection
        if (hasSelection && interactablesSelected is IXRSelectInteractable interactable)
        {
            interactionManager.SelectExit(this, interactable);
        }

        base.OnSelectEntering(args);
    }
}

