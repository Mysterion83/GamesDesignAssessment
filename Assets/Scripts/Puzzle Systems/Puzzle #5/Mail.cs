using System.Collections;
using System.Collections.Generic;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
