using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerScreen : MonoBehaviour
{
    Renderer Mat;
    // Start is called before the first frame update
    void Start()
    {
        Mat = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
