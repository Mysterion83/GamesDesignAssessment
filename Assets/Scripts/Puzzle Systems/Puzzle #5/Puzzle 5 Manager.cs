using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle5Manager : MonoBehaviour
{
    [SerializeField]
    string LockdownCode;

    void Start()
    {
        GenerateCode();
    }
    void GenerateCode()
    {
        LockdownCode = Random.Range(0, 10000).ToString();
        int ZerosToAdd = 4 - LockdownCode.Length;
        for (int i = 0; i < ZerosToAdd; i++)
        {
            LockdownCode = "0" + LockdownCode;
        }
        
        Debug.Log($"Lockdown Code : { LockdownCode }");
    }
    public string GetCode()
    {
        return LockdownCode;
    }
}
