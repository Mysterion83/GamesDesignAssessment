using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5Manager : MonoBehaviour
{
    [SerializeField]
    int LockdownCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateCode()
    {
        LockdownCode = Random.Range(0, LockdownCode);
    }
}
