using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desktop : MonoBehaviour
{
    [SerializeField]
    Apps CurrentApp = Apps.None;

    [SerializeField]
    GameObject MailApp;
    [SerializeField]
    GameObject LockdownApp;


    // Start is called before the first frame update
    void Start()
    {
        UpdateCurrentApp((int)CurrentApp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCurrentApp(int InAppNum)
    {
        CurrentApp = (Apps)InAppNum;
        switch (CurrentApp)
        {
            case Apps.None:
                MailApp.SetActive(false);
                LockdownApp.SetActive(false);
                break;
            case Apps.Mail:
                MailApp.SetActive(true);
                LockdownApp.SetActive(false);
                break;
            case Apps.Lockdown:
                MailApp.SetActive(false);
                LockdownApp.SetActive(true);
                break;
        }
    }
}
