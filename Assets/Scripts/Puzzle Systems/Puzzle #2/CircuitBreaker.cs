using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreaker : MonoBehaviour
{
    [SerializeField]
    public Puzzle2Manager PuzzleManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BreakerOn()
    {
        PuzzleManager.TurnOnCircuitBreaker();
    }
    public void BreakerOff()
    {
        PuzzleManager.TurnOffCircuitBreaker();
    }
}
