using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct InventorySlot
{
    private Item ItemInSlot;
    private int Amount;

    public bool IsFull()
    {
        return Amount >= ItemInSlot.MaxAmount;
    }
    public bool IsEmpty()
    {
        return Amount == 0;
    }
    public void RemoveItem()
    {
        if (IsEmpty())
        {
            throw new Exception("Attempted to remove nothing");
        }
        Amount--;
        if (IsEmpty())
        {
            ItemInSlot = new Item(ItemPool.NullItem);
        }
    }
    public void AddItem(Item InItem)
    {
        if (!IsEmpty()) 
        {
            if (IsFull())
            {
                throw new Exception("Attempted to Add item to Full Slot");
            }
            if (InItem.ID != ItemInSlot.ID)
            {
                throw new Exception("Attempted to Add item of different ID to Filled Slot");
            }
        }
        
        if (IsEmpty())
        {
            ItemInSlot = InItem;
            Amount = Amount + 1;
        }
        else 
        {
            Amount = Amount + 1;
        }
    }
    public int GetID()
    {
        return ItemInSlot.ID;
    }
    public int GetAmount()
    {
        return Amount;
    }
    public string GetName()
    {
        return ItemInSlot.Name;
    }
    public string GetDescription()
    {
        return ItemInSlot.Description;
    }
    public bool HasItem()
    {
        return Amount > 0;
    }
    public int GetMaxAmount()
    {
        return ItemInSlot.MaxAmount;
    }
    public Sprite GetSprite()
    {
        return ItemInSlot.ItemImage;
    }
    public List<ItemTags> GetTags()
    {
        List<ItemTags> tags = new List<ItemTags>();
        foreach (ItemTags tag in ItemInSlot.Tags)
        {
            tags.Add(tag);
        }
        return tags;
    }
}
