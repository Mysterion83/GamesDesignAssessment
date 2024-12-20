using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationLock : InteractableDial
{
    [SerializeField]
    InteractableAnimationObject Anim;
    [SerializeField]
    GameObject Dial;

    [SerializeField]
    int CurrentInput;
    [SerializeField]
    float RawCurrentInput;
    [SerializeField]
    int CodeIndex;

    [Header("Combination Code")]
    [SerializeField]
    int[] Combination;
    [SerializeField]
    float TurnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        CodeIndex = 0;
        GenerateCombination();
    }
    public void Update()
    {
        UpdateDial(CurrentInput);
    }
    void UpdateDial(int CurrentValue)
    {
        Dial.transform.localRotation = Quaternion.Euler(new Vector3(-(((float)CurrentValue * 3.6f)-90), -180, -90));
    }
    public override void Rotate(float Change)
    {
        int OldCurrentInput = CurrentInput;
        RawCurrentInput += Change * TurnSpeed;
        if (RawCurrentInput < 0) RawCurrentInput = 99;
        else if (RawCurrentInput >= 100) RawCurrentInput = 0;
        Debug.Log($"RawInput: {RawCurrentInput}");
        CurrentInput = ((int)RawCurrentInput);
        

        if (Combination[CodeIndex] == CurrentInput)
        {
            CodeIndex++;
            Debug.Log($"Moved to next CodeIndex: {CodeIndex}");
            if (CodeIndex >= Combination.Length)
            {
                OpenSafe();
            }
        }
        else if (CurrentInput != OldCurrentInput) PlaySound();
    }
    void PlaySound()
    {

    }
    void GenerateCombination()
    {
        for (int i = 0; i < Combination.Length; i++)
        {
            Combination[i] = Random.Range(0, 100);
            Debug.Log($"Combination {i}: {Combination[i]}");
        }
    }
    void OpenSafe()
    {
        gameObject.tag = "Untagged";
        Anim.Interact();
    }
}
