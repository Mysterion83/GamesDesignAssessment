using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerScreen : MonoBehaviour
{
    [SerializeField]
    Renderer Mat;
    // Start is called before the first frame update
    void Start()
    {
        TurnOff();
    }
    public void TurnOn()
    {
        Mat.material.color = Color.green;
    }
    public void TurnOff()
    {
        Mat.material.color = Color.red;
    }
}
