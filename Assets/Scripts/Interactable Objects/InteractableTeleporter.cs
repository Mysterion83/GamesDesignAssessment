using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTeleporter : Interactable
{
    GameObject Player;
    [SerializeField]
    Transform TeleportLocation;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Interact()
    {
        Player.transform.position = TeleportLocation.position;
    }
}
