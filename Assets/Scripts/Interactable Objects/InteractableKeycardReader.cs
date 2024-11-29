using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableKeycardReader : InteractableButton
{
    InventorySystem inventory;
    [SerializeField]
    int RequiredItemID;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

    public override void Interact()
    {
        if (inventory.GetCurrentHeldItemID() == RequiredItemID)
        {
            foreach (Interactable objects in ObjectsToInteractWith)
            {
                objects.Interact();
            }
        }
    }
}
