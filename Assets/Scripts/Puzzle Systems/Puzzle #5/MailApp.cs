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
    // Start is called before the first frame update
    void Start()
    {
        
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
}
