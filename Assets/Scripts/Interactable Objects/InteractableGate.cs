using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGate : InteractableKeycardReader
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public override void Interact()
    {
        if (inventory == null)
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
        }
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }
        if (inventory.GetCurrentHeldItemID() == RequiredItemID)
        {
            if (!gm.GetGateUnlocked()) return;
            PlayAudio();
            foreach (Interactable objects in ObjectsToInteractWith)
            {
                objects.Interact();
            }
        }
    }
}
