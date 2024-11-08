using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Manager : MonoBehaviour
{
    [SerializeField]
    bool PuzzleSolved = false;

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

    // Update is called once per frame
    void Update()
    {
        
    }
    void TurnOnCircuitBreaker()
    {
        circuitBreakerOn = true;
        if (IsPuzzleSolved()) PuzzleSolved = true;
    }
    void TurnOffCircuitBreaker()
    {
        circuitBreakerOn = false;
    }
    void InsertFuse()
    {
        FuseInserted = true;
    }
    bool IsPuzzleSolved()
    {
        return circuitBreakerOn && FuseInserted && WiresConnected && VoltageAdjusted;
    }
}
