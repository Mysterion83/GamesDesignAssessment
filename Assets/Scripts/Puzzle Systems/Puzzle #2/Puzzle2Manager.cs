using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Manager : MonoBehaviour
{
    [SerializeField]
    bool PuzzleSolved = false;
    [SerializeField]
    InteractableAnimationObject[] DoorsToOpen;
    [SerializeField]
    bool DoorsOpen;

    [Header("Circuit Breaker")]
    [SerializeField]
    bool circuitBreakerOn = false;
    

    [Header("FuseBox")]
    [SerializeField]
    bool FuseInserted = false;
    

    [Header("WireBox")]
    [SerializeField]
    bool WiresConnected = false;


    [Header("Adjust Voltage")]
    [SerializeField]
    bool VoltageAdjusted = false;
    [SerializeField]
    float VoltageValue;
    [SerializeField]
    float CurrentVoltageValue;
    [SerializeField]
    float VoltageLeeway;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) OpenDoors();
    }
    public void TurnOnCircuitBreaker()
    {
        circuitBreakerOn = true;
        if (IsPuzzleSolved()) PuzzleSolved = true;
    }
    public void TurnOffCircuitBreaker()
    {
        circuitBreakerOn = false;
    }
    public void InsertFuse()
    {
        FuseInserted = true;
    }
    bool IsPuzzleSolved()
    {
        return circuitBreakerOn && FuseInserted && WiresConnected && VoltageAdjusted;
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
}
