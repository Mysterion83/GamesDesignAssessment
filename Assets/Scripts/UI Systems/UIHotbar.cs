using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHotbar : MonoBehaviour
{
    [SerializeField]
    Transform currentslot;
    [SerializeField]
    ItemNameFadeOut Tooltip;
    [SerializeField]
    Image[] HotbarImages;

    void Start()
    {
        Tooltip = gameObject.GetComponentInChildren<ItemNameFadeOut>();
    }

    public void HotbarUpdate(InventorySlot[] slots)
    {
        for (int i = 0; i < slots.Length; i++) 
        {
            HotbarImages[i].sprite = slots[i].GetSprite();
            HotbarImages[i].preserveAspect = true;
        }
    }
    public void CurrentSlotUpdate(int slot, string Name, string Description)
    {
        currentslot.transform.localPosition = new Vector3((slot - 2) * 100,0,0);
        Tooltip.UpdateTooltip(Name,Description);
    }
}
