using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document : Interactable
{
    UIManager uiManager;

    [SerializeField]
    [TextArea(15, 20)]
    public string Text;

    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<UIManager>();
    }

    public override void Interact()
    {
        uiManager.DisplayPopup(Text);
    }
}
