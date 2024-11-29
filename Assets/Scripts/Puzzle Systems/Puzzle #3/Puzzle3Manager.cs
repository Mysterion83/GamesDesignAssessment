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

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateKeycard()
    {
        int PossibleLocations = PossibleKeycardSpawnLocations.Count - 1;
        //Instantiate(KeycardToSpawn, PossibleKeycardSpawnLocations[UnityEngine.Random.Range(0, PossibleLocations)].position, Quaternion.identity);
        Debug.Log("Spawned Keycard");
    }
}
