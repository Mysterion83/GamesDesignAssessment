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
        //string LockdownCode = PuzzleManager.GetCode();
        //char[] Replacement = "1234".ToCharArray();
        //int ReplaceIndex;
        //char LockdownCodeCharacter;
        //for (int i = 0; i < RecievedMail.Length; i++)
        //{

        //    ReplaceIndex = Random.Range(0, LockdownCode.Length);
        //    //Replacement[ReplaceIndex] = LockdownCode[ReplaceIndex];

        //    RecievedMail[i].SetPlaceHolderText(Replacement.ToString());
        //    Replacement[ReplaceIndex] = 'X';
        //}



        string LockdownCode = PuzzleManager.GetCode();
        string Replacement = "1234";
        int currentReplacementChar = 0;
        List<Mail> tempMail = new List<Mail>();
        for (int i = 0; i < RecievedMail.Length; i++)
        {
            tempMail.Add(RecievedMail[i]);
        }
        int currentMail;
        for (int i = 0; i < LockdownCode.Length; ++i)
        {
            currentMail = Random.Range(0, tempMail.Count);
            tempMail[currentMail].SetPlaceHolderText(GetReplacementCode(LockdownCode, i));
            tempMail.RemoveAt(currentMail);
        }
        tempMail[0].SetPlaceHolderText("[REDACTED]");
    }
    string GetReplacementCode(string InCode, int CharToKeep)
    {
        string output = "";

        for (int i = 0; i < InCode.Length; ++i) 
        {
            if (i == CharToKeep)
            {
                output += InCode[i];
            }
            else
            {
                output += "X";
            }
        }
        return output;
    }
}
