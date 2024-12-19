using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5Manager : MonoBehaviour
{
    [SerializeField]
    string LockdownCode;
    // Start is called before the first frame update
    void Start()
    {
        GenerateCode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateCode()
    {
        LockdownCode = Random.Range(0, 1000).ToString();
        for (int i = 0; i < 4 - LockdownCode.Length; i++)
        {
            LockdownCode = "0" + LockdownCode;
        }
        Debug.Log($"Lockdown Code : { LockdownCode}");
    }
    public string GetCode()
    {
        return LockdownCode;
    }
}
