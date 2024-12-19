using System.Collections.Generic;
using UnityEngine;

public class PreMadeMail
{

    public static List<MailContents> MailList;

    public static void GenerateMail()
    {

    }

    public static MailContents GetMail()
    {
        int ReturnIndex = Random.Range(0, MailList.Count);
        MailContents ReturnMail;


        ReturnMail.SenderName = MailList[ReturnIndex].SenderName;
        ReturnMail.Date = MailList[ReturnIndex].Date;
        ReturnMail.Header = MailList[ReturnIndex].Header;
        ReturnMail.Body = MailList[ReturnIndex].Body;


        MailList.RemoveAt(ReturnIndex);
        return ReturnMail;
    }
}
