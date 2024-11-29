using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    [SerializeField]
    protected Interactable[] ObjectsToInteractWith;

    public override void Interact()
    {
        foreach (Interactable objects in ObjectsToInteractWith)
        {
            objects.Interact();
        }
    }
}
