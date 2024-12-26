using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : Interactable
{
    GameManager gm;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public override void Interact()
    {
        gm.LoadEnding();
    }
}
