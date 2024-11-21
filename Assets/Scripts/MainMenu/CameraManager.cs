using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Camera Positions")]
    [SerializeField]
    List<Transform> Positions;
    [SerializeField]
    int CurrentPostion;

    [Header("Camera Switch Speed")]
    [SerializeField]
    float SwitchTime;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = SwitchTime;
        UpdatePosition();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            CurrentPostion = (CurrentPostion+1) % Positions.Count;
            currentTime = SwitchTime;
            UpdatePosition();
        }
    }
    void UpdatePosition()
    {
        transform.position = Positions[CurrentPostion].position;
        transform.rotation = Positions[CurrentPostion].rotation;
    }
}
