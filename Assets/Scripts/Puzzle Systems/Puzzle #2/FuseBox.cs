using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FuseBox : InteractableKeycardReader
{
    [SerializeField]
    Puzzle2Manager PuzzleManager;
    public override void Interact()
    {
        if (inventory.GetCurrentHeldItemID() == RequiredItemID)
        {
            inventory.RemoveItem(ItemPool.GetItemViaID(5));
            PuzzleManager.InsertFuse();
        }
    }
}
