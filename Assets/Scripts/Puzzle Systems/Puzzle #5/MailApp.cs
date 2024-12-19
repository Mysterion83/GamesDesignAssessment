using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MailApp : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI Text;
    [SerializeField]
    public Mail[] RecievedMail;
    [SerializeField]
    Puzzle5Manager PuzzleManager;
    // Start is called before the first frame update
    void Start()
    {
        ReplacePlaceHolders();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCurrentMail(int InCurrent)
    {
        if (InCurrent == -1)
        {
            Text.text = "";
        }
        else
        {
            Text.text = RecievedMail[InCurrent].GetText();
        }
    }
    void ReplacePlaceHolders()
    {
        string LockdownCode = PuzzleManager.GetCode();
        char[] Replacement = "XXXX".ToCharArray();
        int ReplaceIndex;
        for (int i = 0; i < RecievedMail.Length; i++)
        {
            ReplaceIndex = Random.Range(0, LockdownCode.Length);
            //Replacement[ReplaceIndex] = LockdownCode[ReplaceIndex];

            RecievedMail[i].SetPlaceHolderText(Replacement.ToString());
            Replacement[ReplaceIndex] = 'X';
        }
    }
}
