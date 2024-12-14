using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mail : MonoBehaviour
{
    [SerializeField]
    string SenderName;
    [SerializeField]
    string Date;
    [SerializeField]
    string Header;
    [SerializeField]
    [TextArea(15, 20)]
    string Body;
    [SerializeField]
    TextMeshProUGUI TMPText;
    // Start is called before the first frame update
    void Start()
    {
        TMPText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        SetMailText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetMailText()
    {
        string text = SenderName;
        text += $" {Date}";
        text += $"\n\n{Header}";
        TMPText.text = text;
    }
    public string GetText()
    {
        string text = SenderName;
        text += $" {Date}";
        text += $"\n\n{Header}";
        text += $"\n\n{Body}";
        return text;
    }
}
