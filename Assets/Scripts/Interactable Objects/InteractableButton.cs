using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    [SerializeField]
    Interactable ObjectToInteractWith;

    public override void Interact()
    {
        ObjectToInteractWith.Interact();
    }
}
