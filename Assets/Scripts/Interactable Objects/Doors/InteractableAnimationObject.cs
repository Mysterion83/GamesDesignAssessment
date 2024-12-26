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
    [SerializeField]
    AudioSource Audio;
    
    public override void Interact()
    {
        if (!IsOn)
        {
            IsOn = true;
            if (Audio != null) Audio.Play();
            Anim.SetBool(AnimBoolName, true);
        }
        else
        {
            IsOn = false;
            if (Audio != null) Audio.Play();
            Anim.SetBool(AnimBoolName, false);
        }
    }
    public bool GetIsOn()
    {
        return IsOn;
    }
}
