using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3Manager : MonoBehaviour
{
    [SerializeField]
    List<Transform> PossibleKeycardSpawnLocations;
    [SerializeField]
    GameObject KeycardToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        GenerateKeycard();
    }
    void GenerateKeycard()
    {
        int PossibleLocations = PossibleKeycardSpawnLocations.Count - 1;
        Instantiate(KeycardToSpawn, PossibleKeycardSpawnLocations[UnityEngine.Random.Range(0, PossibleLocations)].position, Quaternion.Euler(-90,0,0));
        Debug.Log("Spawned Keycard");
    }
}
