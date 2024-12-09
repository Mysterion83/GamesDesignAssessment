using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected string AdditionalToolTip = null;
    public string GetAdditionalToolTip()
    {
        return AdditionalToolTip;
    }
    public virtual void Interact()
    {

    }
}
