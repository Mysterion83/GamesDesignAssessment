using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server : Interactable
{
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
        TurnOff();
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
        PuzzleManager.UpdateCell(x,y);
    }
}
