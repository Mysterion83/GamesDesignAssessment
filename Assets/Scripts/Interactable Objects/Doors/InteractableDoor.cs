using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableAnimationObject : Interactable
{
    [SerializeField]
    Animator Anim = null;
    [SerializeField]
    bool IsOn = false;
    [SerializeField]
    string AnimBoolName = "";

    [Header("OLD")]
    [SerializeField]
    string OnAnimName = "DoorOpen";
    [SerializeField]
    string OffAnimName = "DoorClose";
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InteractOld()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName(OnAnimName)) return;
        //Door.SetBool("IsClosed", false);
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName(OffAnimName)) return;
        if (!IsOn)
        {
            Anim.Play(OnAnimName, 0, 0);
            IsOn = true;
        }
        else 
        {
            Anim.Play(OffAnimName, 0, 0);
            IsOn = false;
        }
    }
    public override void Interact()
    {
        if (!IsOn)
        {
            Anim.SetBool(AnimBoolName, true);
        }
        else
        {
            Anim.SetBool(AnimBoolName, false);
        }
    }
}
