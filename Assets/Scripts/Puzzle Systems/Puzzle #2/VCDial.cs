using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCDial : InteractableDial
{
    [SerializeField]
    VoltageController VC;
    public override void Rotate(float input)
    {
        VC.Rotate(input);
    }
}
