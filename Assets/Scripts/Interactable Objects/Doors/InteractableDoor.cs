using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{
    [SerializeField]
    Animator Door = null;
    [SerializeField]
    string DoorOpenAnimName = "DoorOpen";
    [SerializeField]
    string DoorCloseAnimName = "DoorClose";
    [SerializeField]
    bool IsOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        if (Door.GetCurrentAnimatorStateInfo(0).IsName(DoorOpenAnimName)) return;
        if (Door.GetCurrentAnimatorStateInfo(0).IsName(DoorCloseAnimName)) return;
        if (!IsOpen)
        {
            Door.Play(DoorOpenAnimName, 0, 0);
            IsOpen = true;
        }
        else 
        {
            Door.Play(DoorCloseAnimName, 0, 0);
            IsOpen = false;
        }
    }
}
