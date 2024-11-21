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
    bool isCorrectConbimation(int InCombination, int CombinationIndex)
    {
        return Combination[CombinationIndex] == InCombination;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateCombination()
    {
        for(int i = 0; i < Combination.Length; i++)
        {
            Combination[i] = Random.Range(0,360);
            Debug.Log($"Combination {i}: {Combination[i]}");
        }
    }
}
