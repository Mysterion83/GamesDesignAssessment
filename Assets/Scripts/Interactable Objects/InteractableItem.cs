using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : Interactable
{
    [SerializeField]
    int ItemID;

    InventorySystem PlayerInventory;
    Item ItemToGive;
    // Start is called before the first frame update
    void Start()
    {
        ItemToGive = ItemPool.GetItemViaID(ItemID);
        PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
    }

    public override void Interact()
    {
        PlayerInventory.AddItem(ItemToGive);
        Debug.Log("Interacted with object");
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
