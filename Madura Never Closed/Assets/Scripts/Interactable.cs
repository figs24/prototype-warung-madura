using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool useEvents;
    
    public void BaseInteract()
    {
        if(useEvents)
            GetComponent<InteractionEvent>().onInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {
        
    }
}