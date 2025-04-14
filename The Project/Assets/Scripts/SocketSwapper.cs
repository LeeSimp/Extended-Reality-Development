using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketSwapper : MonoBehaviour
{
    // Start is called before the first frame update
    private XRSocketInteractor socket;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }
    public void TrySwap(XRBaseInteractable interactable)
    {
        if(socket.hasSelection)
        {
            var oldInteractable = socket.interactablesSelected;
            socket.EndManualInteraction();
            socket.interactionManager.SelectExit(socket, (IXRSelectInteractable)oldInteractable);
        }
        interactionManager.SelectExit(socket, interactable);
    }
}
