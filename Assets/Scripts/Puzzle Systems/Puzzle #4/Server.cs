using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Interactable
{
    AudioSource Audio;
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;
    [SerializeField]
    Puzzle4Manager PuzzleManager;
    [SerializeField]
    Renderer ScreenMat;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        TurnOn();
    }
    public void TurnOn()
    {
        ScreenMat.material.color = Color.green;
    }
    public void TurnOff()
    {
        ScreenMat.material.color = Color.red;
    }
    public override void Interact()
    {
        Audio.Play();
        PuzzleManager.UpdateCell(x,y);
    }
}
