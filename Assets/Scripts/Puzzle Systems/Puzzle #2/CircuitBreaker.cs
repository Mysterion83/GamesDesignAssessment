using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircuitBreaker : MonoBehaviour
{
    [SerializeField]
    public Puzzle2Manager PuzzleManager;
    [SerializeField]
    public InteractableAnimationObject Lever;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Lever.GetIsOn())
        {
            BreakerOn();
        }
        else BreakerOff();
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
