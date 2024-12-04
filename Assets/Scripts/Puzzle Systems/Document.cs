using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : Interactable
{
    
    UIManager uiManager;

    [SerializeField]
    [TextArea(15, 20)]
    public string Text;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        uiManager.DisplayPopup(Text);
    }
}
