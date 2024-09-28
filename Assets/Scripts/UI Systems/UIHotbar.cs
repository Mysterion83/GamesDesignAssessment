using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHotbar : MonoBehaviour
{
    [SerializeField]
    Transform currentslot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HotbarUpdate(InventorySlot[] slots)
    {

    }
    public void CurrentSlotUpdate(int slot)
    {
        currentslot.transform.localPosition = new Vector3((slot - 2) * 100,0,0);
    }
}
