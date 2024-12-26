using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.Rendering;

public class CombinationLock : InteractableDial
{
    AudioController Audio;
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
        Audio = GetComponent<AudioController>();
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
        CurrentInput = ((int)RawCurrentInput);
        

        if (Combination[CodeIndex] == CurrentInput)
        {
            if (Combination.Length < CodeIndex-1) Audio.Play(2, 1, 1);
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
        float volume = math.abs(CurrentInput - Combination[CodeIndex]);
        volume = 1 / volume;
        volume = math.clamp(volume, 0, 1);
        Audio.Play(0, volume, 1);
    }
    void GenerateCombination()
    {
        for (int i = 0; i < Combination.Length; i++)
        {
            Combination[i] = UnityEngine.Random.Range(0, 100);
            Debug.Log($"Combination {i}: {Combination[i]}");
        }
    }
    void OpenSafe()
    {
        gameObject.tag = "Untagged";
        Anim.Interact();
        Audio.Play(1, 0.5f, 1);
    }
}
