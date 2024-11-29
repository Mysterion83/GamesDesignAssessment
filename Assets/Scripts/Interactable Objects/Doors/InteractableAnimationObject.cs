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
    
    public override void Interact()
    {
        if (!IsOn)
        {
            IsOn = true;
            Anim.SetBool(AnimBoolName, true);
        }
        else
        {
            IsOn = false;
            Anim.SetBool(AnimBoolName, false);
        }
    }
    public bool GetIsOn()
    {
        return IsOn;
    }
}
