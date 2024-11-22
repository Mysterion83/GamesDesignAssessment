using System.Collections;
using UnityEngine;

public class Puzzle1Manager : MonoBehaviour
{
    [SerializeField]
    bool Solved;


    [Header("Combination Code")]
    [SerializeField]
    int[] Combination;
    // Start is called before the first frame update
    void Start()
    {
        GenerateCombination();
    }
    public bool isCorrectConbimation(int InCombination, int CombinationIndex)
    {
        return Combination[CombinationIndex] == InCombination;
    }
    void GenerateCombination()
    {
        for(int i = 0; i < Combination.Length; i++)
        {
            Combination[i] = Random.Range(0,100);
            Debug.Log($"Combination {i}: {Combination[i]}");
        }
    }
    public int GetCombinationLength()
    {
        return Combination.Length;
    }
    public void SetSolved(bool IsSolved)
    {
        Solved = IsSolved;
    }
}
