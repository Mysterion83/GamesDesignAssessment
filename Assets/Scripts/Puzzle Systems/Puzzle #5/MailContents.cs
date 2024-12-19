using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MailContents
{
    [SerializeField]
    public string SenderName;
    [SerializeField]
    public string Date;
    [SerializeField]
    public string Header;
    [SerializeField]
    public string Body;

    public MailContents(string inSenderName, string InDate, string InHeader, string InBody)
    {
        SenderName = inSenderName;
        Date = InDate;
        Header = InHeader;
        Body = InBody;
    }
}
