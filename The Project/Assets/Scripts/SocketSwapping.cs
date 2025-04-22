using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSwapping : XRSocketInteractor
{
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        if (hasSelection)
        {
            interactionManager.SelectExit(this, firstInteractableSelected);
        }

        base.OnSelectEntering(args);
    }
}
