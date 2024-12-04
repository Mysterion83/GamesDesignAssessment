using System;
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
    [SerializeField]
    GameObject FuseObjectToSpawn;
    [SerializeField]
    List<Transform> PossibleFuseLocations;
    

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
        GenerateFuse();
    }
    private void Update()
    {

    }
    public void TurnOnCircuitBreaker()
    {
        circuitBreakerOn = true;
        if (IsPuzzleSolved())
        {
            PuzzleSolved = true;
            OpenDoors();
        }
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
    void GenerateFuse()
    {
        int PossibleLocations = PossibleFuseLocations.Count-1;
        Instantiate(FuseObjectToSpawn, PossibleFuseLocations[UnityEngine.Random.Range(0, PossibleLocations)].position,Quaternion.identity);
        Debug.Log("Spawned Fuse");
    }
}
