using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingSystem : MonoBehaviour
{
    [SerializeField]
    public bool IsBlinking = false;
    [SerializeField]
    public float BlinkingTimer;
    [SerializeField]
    public float CurrentBlinkTimer;
    [SerializeField]
    public float BlinkDuration;
    [SerializeField]
    public GameObject BlinkPanel;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBlinkTimer = BlinkingTimer;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentBlinkTimer -= Time.deltaTime;
        if (IsBlinking && CurrentBlinkTimer <= 0 - BlinkDuration) 
        {
            IsBlinking = false;
            CurrentBlinkTimer = BlinkingTimer;
            BlinkPanel.transform.localPosition = Vector3.zero;
            Debug.Log("Stopped Blinking");
        }
        else if (CurrentBlinkTimer <= 0 && !IsBlinking)
        {
            IsBlinking = true;
            BlinkPanel.transform.localPosition = new Vector3 (0f, 0f, 0.3f);
            Debug.Log("Blinking");
        }
    }
}
