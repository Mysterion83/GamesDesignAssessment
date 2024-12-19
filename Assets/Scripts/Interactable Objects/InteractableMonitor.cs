using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableMonitor : Interactable
{
    [SerializeField]
    Monitor MonitorToInteract;
    public override void Interact()
    {
        Debug.Log("Interacted With Monitor Collider");
        MonitorToInteract.MonitorInteract();
    }
}
