using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    [SerializeField]
    Puzzle1Manager PuzzleManager;
    [SerializeField]
    GameObject Dial;

    [SerializeField]
    int CurrentInput;
    [SerializeField]
    int CodeIndex;
    // Start is called before the first frame update
    void Start()
    {
        CodeIndex = 0;
    }
    void UpdateDial(int CurrentValue)
    {
        Dial.transform.localRotation = Quaternion.Euler(new Vector3((float)CurrentValue*3.6f, 0, 0));
    }
    void InputCode()
    {
        if (PuzzleManager.isCorrectConbimation(CurrentInput, CodeIndex))
        {
            CodeIndex++;
            if (CodeIndex == PuzzleManager.GetCombinationLength()) PuzzleManager.SetSolved(true);x
        }
        else
        {
            CodeIndex = 0;
        }
    }
}
