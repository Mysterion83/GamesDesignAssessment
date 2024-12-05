using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle4Manager : Interactable
{
    [SerializeField]
    public bool PuzzleComplete = false;
    [SerializeField]
    public int[,] LightsLayout; //x,y 
    [SerializeField]
    public ServerScreen[] ScreenLights;
    ServerScreen[,] ScreenLights2D;
    [SerializeField]
    public Server[] ServerRacks;
    Server[,] ServerRacks2D;

    [SerializeField]
    InteractableAnimationObject[] DoorsToOpen;
    [SerializeField]
    bool DoorsOpen;

    //-1 = Off, 0 = Doesn't matter, 1 = on, 2d arrays aren't supported by the inspector ;-;
    // Start is called before the first frame update
    void Start()
    {
        GetDefaultLayout();
    }
    void GetDefaultLayout()
    {
        LightsLayout = new int[,] { { -1, -1, 0, 0 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };
        PutScreensAndServersTo2D();
        UpdateServersAndScreens();
    }
    void PutScreensAndServersTo2D()
    {
        ScreenLights2D = new ServerScreen[LightsLayout.GetLength(0), LightsLayout.GetLength(1)];
        ServerRacks2D = new Server[LightsLayout.GetLength(0), LightsLayout.GetLength(1)];
        int index = 0;
        for (int i = 0; i < LightsLayout.GetLength(0); i++)
        {
            for (int j = 0; j < LightsLayout.GetLength(1); j++)
            {
                if (i == 0 && j == 2) ;
                else if (i == 0 && j == 3);
                else 
                {
                    ScreenLights2D[i, j] = ScreenLights[index];
                    ServerRacks2D[i, j] = ServerRacks[index];
                    index++;
                }
            }
        }
    }
    void CheckIsComplete()
    {
        for (int i = 0; i < LightsLayout.GetLength(0); i++)
        {
            for (int j = 0; j < LightsLayout.GetLength(1); j++)
            {
                if (LightsLayout[i,j] == -1)
                {
                    return;
                }
            }
        }
        OpenDoors();
        PuzzleComplete = true;
    }
    void OpenDoors()
    {
        if (DoorsOpen) return;
        foreach (InteractableAnimationObject door in DoorsToOpen)
        {
            door.Interact();
        }
        DoorsOpen = true;
    }
    public void UpdateCell(int X, int Y)
    {
        if (PuzzleComplete) return;
        LightsLayout[X, Y] *= -1;

        if (X > 0) LightsLayout[X-1, Y] *= -1;
        if (Y > 0) LightsLayout[X, Y-1] *= -1;

        if (X < LightsLayout.GetLength(0)-1) LightsLayout[X + 1, Y] *= -1;
        if (Y < LightsLayout.GetLength(1)-1) LightsLayout[X, Y + 1] *= -1;

        UpdateServersAndScreens();
        CheckIsComplete();
    }
    void UpdateServersAndScreens()
    {
        for (int i = 0; i < LightsLayout.GetLength(0); i++)
        {
            for (int j = 0; j < LightsLayout.GetLength(1); j++)
            {
                if (LightsLayout[i,j] == -1)
                {
                    ServerRacks2D[i, j].TurnOff();
                    //ScreenLights2D[i, j].TurnOff();
                }
                else if (LightsLayout[i, j] == 1)
                {
                    ServerRacks2D[i, j].TurnOn();
                    //ScreenLights2D[i, j].TurnOn();
                }
            }
        }
    }
    public override void Interact()
    {
        GetDefaultLayout();
    }
}
