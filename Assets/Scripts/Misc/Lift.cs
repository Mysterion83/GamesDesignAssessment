using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : Interactable
{
    [SerializeField]
    float LiftTimer = 5f;
    float CurrentTimer = 5f;
    [SerializeField] bool Interacted = false;
    GameManager gm;
    private void Start()
    {
        CurrentTimer = LiftTimer;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public override void Interact()
    {
        Interacted = true;
    }
    private void Update()
    {
        if (!Interacted) return;
        CurrentTimer -= Time.deltaTime;
        if (CurrentTimer < 0) gm.LoadEnding();
    }
}
