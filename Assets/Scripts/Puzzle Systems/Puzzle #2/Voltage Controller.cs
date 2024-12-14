using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class VoltageController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField]
    Puzzle2Manager PuzzleManager;
    [SerializeField]
    GameObject TargetVoltagePanel;
    [SerializeField]
    TextMeshProUGUI VoltageText;

    [Header("Voltage Values")]
    [SerializeField]
    float TargetVoltageValue;
    [SerializeField]
    float MinVoltage;
    [SerializeField]
    float MaxVoltage;
    [SerializeField]
    float CurrentVoltageValue;
    [SerializeField]
    float VoltageLeeway;

    // Start is called before the first frame update
    void Start()
    {
        GenerateVoltage();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDial(0);
        UpdateTargetVoltagePanel();
    }
    void UpdateDial(int CurrentValue)
    {
        
    }
    void UpdateTargetVoltagePanel()
    {
        float tmp = math.abs(CurrentVoltageValue - TargetVoltageValue);
        TargetVoltagePanel.transform.localScale = new Vector3((float)math.clamp((double)1 / (double)tmp, 0.1, 1), 1, 1);
        float text = CurrentVoltageValue;
        VoltageText.text = $"{text}V";
    }
    void GenerateVoltage()
    {
        TargetVoltageValue = math.round(UnityEngine.Random.Range(MinVoltage*100,MaxVoltage*100))/100;
    }
    void CheckifComplete()
    {
        if (math.abs(TargetVoltageValue - CurrentVoltageValue) - VoltageLeeway < 0)
        {
            PuzzleManager.SetVoltageAdjusted();
        }
    }
}
