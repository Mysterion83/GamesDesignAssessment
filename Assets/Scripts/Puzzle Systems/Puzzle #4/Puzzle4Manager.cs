using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Puzzle4Manager : MonoBehaviour
{
    [SerializeField]
    public bool PuzzleComplete = false;
    [SerializeField]
    public int[,] LightsLayout; //x,y 
    [SerializeField]
    public GameObject[] ScreenLights;
    GameObject[,] ScreenLights2D;
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
        LightsLayout = new int[,] { { -1, -1, 0, 0 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };
        PutScreensAndServersTo2D();
        UpdateServers();
    }
    void PutScreensAndServersTo2D()
    {
        ScreenLights2D = new GameObject[LightsLayout.GetLength(0), LightsLayout.GetLength(1)];
        ServerRacks2D = new Server[LightsLayout.GetLength(0), LightsLayout.GetLength(1)];
        int index = 0;
        for (int i = 0; i < LightsLayout.GetLength(0); i++)
        {
            for (int j = 0; j < LightsLayout.GetLength(1); j++)
            {
                if (i == 0 && j == 2) ;
                else if (i == 0 && j == 3) ;
                else 
                {
                    ScreenLights2D[i, j] = ScreenLights[index];
                    ServerRacks2D[i, j] = ServerRacks[index];
                    index++;
                }
                //if (i == 2 && j == 0);
                //else if (j == 3 && i == 0);
                //else
                //{
                //    ScreenLights2D[i, j] = ScreenLights[index];
                //    ServerRacks2D[i, j] = ServerRacks[index];
                //    index++;
                //}
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
        PuzzleComplete = true;
    }
    public void UpdateCell(int X, int Y)
    {
        if (PuzzleComplete) return;
        LightsLayout[X, Y] *= -1;
        if (X > 0) LightsLayout[X-1, Y] *= -1;
        if (Y > 0) LightsLayout[X, Y-1] *= -1;
        if (X < LightsLayout.GetLength(0)) LightsLayout[X + 1, Y] *= -1;
        if (Y < LightsLayout.GetLength(1)) LightsLayout[X, Y + 1] *= -1;
        UpdateServers();
        CheckIsComplete();
    }
    void UpdateServers()
    {
        for (int i = 0; i < LightsLayout.GetLength(0); i++)
        {
            for (int j = 0; j < LightsLayout.GetLength(1); j++)
            {
                if (LightsLayout[i,j] == -1)
                {
                    ServerRacks2D[i, j].TurnOff();
                }
                else if (LightsLayout[i, j] == 1)
                {
                    ServerRacks2D[i, j].TurnOn();
                }
            }
        }
    }
}
