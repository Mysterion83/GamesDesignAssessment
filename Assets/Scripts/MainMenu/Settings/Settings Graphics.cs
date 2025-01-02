using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SettingsGraphics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetShadows(int On)
    {
        if (On == 0)
        {
            Camera.main.GetUniversalAdditionalCameraData().renderShadows = true;
        }
        else
        {
            Camera.main.GetUniversalAdditionalCameraData().renderShadows = false;
        }
        
    }
}
