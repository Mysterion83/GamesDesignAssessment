using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LockdownApp : MonoBehaviour
{
    [SerializeField]
    Monitor ComputerMonitor;
    [SerializeField]
    GameManager gm;
    [SerializeField]
    Puzzle5Manager PuzzleManager;

    [SerializeField]
    public TMP_InputField UserInput;

    [SerializeField]
    public TextMeshProUGUI AttemptsText;

    int TriesLeft = 3;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        UpdateAttemptText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UnlockGate()
    {
        gm.UnlockGate();
    }
    public void SubmitAnswer()
    {
        if (UserInput.text != null | UserInput.text != "")
        {
            if (UserInput.text == GetCode() || gm.GetGateUnlocked())
            {
                UnlockGate();
                UserInput.DeactivateInputField();
                ComputerMonitor.MonitorQuit();
            }
            else
            {
                TriesLeft--;
                if (TriesLeft <= 0) 
                {
                    ComputerMonitor.MonitorQuit();
                    gm.KillPlayer();
                }
                else
                {
                    UpdateAttemptText();
                }
            }
        }
    }
    void UpdateAttemptText()
    {
        AttemptsText.text = $"Memetic Kill Agent will be released after {TriesLeft} attempts";
    }
    public string GetCode()
    {
        return PuzzleManager.GetCode();
    }
}
