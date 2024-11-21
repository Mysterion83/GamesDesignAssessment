using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingSystem : MonoBehaviour
{
    [SerializeField]
    public bool IsBlinking = false;
    [SerializeField]
    public bool InBlinkingArea = false;
    [SerializeField]
    public float BlinkingTimer;
    [SerializeField]
    public float CurrentBlinkTimer;
    [SerializeField]
    public float BlinkDuration;
    [SerializeField]
    public GameObject BlinkPanel;
    [SerializeField]
    public Transform BlinkBar;
    [SerializeField]
    public Transform BlinkBarGauge;
    // Start is called before the first frame update
    void Start()
    {
        CurrentBlinkTimer = BlinkingTimer;
        DisableUIBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (!InBlinkingArea) return;
        CurrentBlinkTimer -= Time.deltaTime;
        UpdateBlinkBar();
        if (IsBlinking && CurrentBlinkTimer <= 0 - BlinkDuration) 
        {
            IsBlinking = false;
            CurrentBlinkTimer = BlinkingTimer;
            BlinkPanel.SetActive(false);
            BlinkBarGauge.transform.localScale = new Vector3(1, .8f, 1);
            Debug.Log("Stopped Blinking");
        }
        else if ((Input.GetKeyDown(KeyCode.Space) ^ CurrentBlinkTimer <= 0) && !IsBlinking)
        {
            CurrentBlinkTimer = 0;
            IsBlinking = true;
            BlinkPanel.SetActive(true);
            Debug.Log("Blinking");
        }
    }
    void UpdateBlinkBar()
    {
        float scaleVal = CurrentBlinkTimer / BlinkingTimer;
        if (scaleVal < 0) scaleVal = 0;
        BlinkBarGauge.localScale = new Vector3(scaleVal, .8f, 1);
    }
    void BlinkAreaEnter()
    {
        InBlinkingArea = true;
        EnableUIBar();
    }
    void BlinkAreaLeave()
    {
        InBlinkingArea = false;
        DisableUIBar();
    }
    void EnableUIBar()
    {
        BlinkBar.transform.localScale = new Vector3(1, 1, 1);
    }
    void DisableUIBar()
    {
        BlinkBar.transform.localScale = new Vector3(0,1,1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BlinkingArea")
        {
            BlinkAreaEnter();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "BlinkingArea")
        {
            BlinkAreaLeave();
        }
    }
}
