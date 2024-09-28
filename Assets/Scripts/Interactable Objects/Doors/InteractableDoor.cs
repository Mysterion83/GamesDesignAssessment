using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{
    [SerializeField]
    bool IsLocked;
    [SerializeField]
    bool IsOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        if (!IsLocked)
        {
            if (!IsOpen) 
            {
                Open();
            }
            else 
            {
                Close();
            }
        }
    }
    void Open()
    {
        IsOpen = true;
        gameObject.SetActive(false);
        throw new NotImplementedException();
    }
    void Close()
    {
        IsOpen = false;
        throw new NotImplementedException();
    }
}
