using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    ItemSlot[] Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Inventory = new ItemSlot[4];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
