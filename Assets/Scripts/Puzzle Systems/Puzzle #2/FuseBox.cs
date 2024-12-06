using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class FuseBox : InteractableKeycardReader
{
    [SerializeField]
    GameObject Fuse;

    public void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventorySystem>();
        Fuse.SetActive(false);
    }

    [SerializeField]
    Puzzle2Manager PuzzleManager;
    public override void Interact()
    {
        if (inventory.GetCurrentHeldItemID() == RequiredItemID)
        {
            Fuse.SetActive(true);
            inventory.RemoveItem(ItemPool.GetItemViaID(5));
            PuzzleManager.InsertFuse();
        }
    }
}
