using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            QualitySettings.shadows = ShadowQuality.All;
        }
        else
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        
    }
}
