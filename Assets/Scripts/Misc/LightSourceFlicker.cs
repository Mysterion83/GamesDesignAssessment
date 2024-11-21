using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LightSourceFlicker : MonoBehaviour
{
    [SerializeField]
    public float Intensity;
    [SerializeField]
    public float FlickerSpeed;

    Light FlickingLight;
    float BaseIntensity;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        FlickingLight = GetComponentInChildren<Light>();
        BaseIntensity = FlickingLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        FlickingLight.intensity = (math.sin(time * FlickerSpeed) * Intensity) + BaseIntensity;
    }
}
