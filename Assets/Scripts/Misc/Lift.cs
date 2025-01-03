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
    AudioController AC;
    private void Start()
    {
        CurrentTimer = LiftTimer;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        AC = GetComponent<AudioController>();
    }
    public override void Interact()
    {
        Interacted = true;
        AC.Play(0, 0.5f, 1);
    }
    private void Update()
    {
        if (!Interacted) return;
        CurrentTimer -= Time.deltaTime;
        if (CurrentTimer < 0) gm.LoadEnding();
    }
}
