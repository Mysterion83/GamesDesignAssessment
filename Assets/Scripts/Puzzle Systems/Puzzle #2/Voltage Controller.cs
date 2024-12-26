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
    [SerializeField]
    GameObject Dial;
    [SerializeField]
    GameObject DialCollider;
    AudioSource Audio;

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
    float VoltageLeeway = 2.5f;

    [Header("Dial Values")]
    [SerializeField]
    float TurnSpeed = 1f;
    [SerializeField]
    float CurrentRotation = 0;


    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        GenerateVoltage();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDial(CurrentRotation);
        UpdateTargetVoltagePanel();
    }
    void UpdateDial(float CurrentValue)
    {
        Dial.transform.localRotation = Quaternion.Euler(new Vector3(90-(CurrentRotation),90,90));
    }
    void UpdateTargetVoltagePanel()
    {
        float tmp = math.abs(CurrentVoltageValue - TargetVoltageValue);
        //float XValue = math.clamp((-math.log(math.pow(tmp, 5) - VoltageLeeway*40)) + math.sqrt(72.16248f)/10,0,1);
        float XValue = ((-0.025f/4f) * tmp) + 1f + (0.0625f/4f);
        XValue = math.clamp(XValue, 0.05f, 1);
        TargetVoltagePanel.transform.localScale = new Vector3(XValue, 1, 1);
        float text = math.round(CurrentVoltageValue*100)/100;
        VoltageText.text = $"{text}V";
    } 
    void GenerateVoltage()
    {
        TargetVoltageValue = math.round(UnityEngine.Random.Range(MinVoltage*100,MaxVoltage*100))/100;
        CurrentVoltageValue = math.round(UnityEngine.Random.Range(MinVoltage * 100, MaxVoltage * 100)) / 100;
    }
    void CheckifComplete()
    {
        if (math.abs(TargetVoltageValue - CurrentVoltageValue) - VoltageLeeway < 0)
        {
            PuzzleManager.SetVoltageAdjusted();
            DialCollider.tag = "Untagged";
        }
    }
    public void Rotate(float input)
    {
        float OldRotation = CurrentRotation;
        CurrentRotation += input * TurnSpeed * 5;
        CurrentRotation %= 360;
        CurrentVoltageValue += input * TurnSpeed;
        CurrentVoltageValue = math.clamp(CurrentVoltageValue, MinVoltage, MaxVoltage);
        if (OldRotation != CurrentRotation)
        {
            Audio.Play();
        }
        CheckifComplete();
    }
}
