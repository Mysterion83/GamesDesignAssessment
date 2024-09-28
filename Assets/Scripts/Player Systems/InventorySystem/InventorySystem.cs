using System;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    /// <summary>
    /// Note to self: Weird bug when all slots but one are full with the last one only having one item, if you add another it wont incredment the amount
    /// </summary>

    [SerializeField]
    UIManager UI;

    [SerializeField]
    int SlotsAmount;

    [SerializeField]
    InventorySlot[] Inventory;

    [SerializeField]
    int CurrentHeldItemIndex = 0;

    private void Start()
    {
        Inventory = new InventorySlot[SlotsAmount];
        //for (int i = 0; i < 999; i++)
        //{
        //    AddItem(ItemPool.GetItemViaID(1));
        //}
    }
    private void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            CurrentHeldItemIndex = (CurrentHeldItemIndex + 1) % SlotsAmount;
            UI.CurrentSlotUpdate(CurrentHeldItemIndex);
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            CurrentHeldItemIndex--;
            if (CurrentHeldItemIndex < 0)
            {
                CurrentHeldItemIndex = SlotsAmount - 1;
            }
            UI.CurrentSlotUpdate(CurrentHeldItemIndex);
        }
    }
    public bool AreSlotsOccupied()
    {
        foreach (InventorySlot slot in Inventory) 
        {
            if (slot.GetID() == 0)
            {
                return false;
            }
        }
        return true;
    }
    public bool isEmpty()
    {
        foreach (InventorySlot slot in Inventory)
        {
            if (slot.HasItem())
            {
                return false;
            }
        }
        return true;
    }
    public bool HasItem(int ID)
    {
        foreach (InventorySlot slot in Inventory)
        {
            if (slot.GetID() == ID)
            {
                return true;
            }
        }
        return false;
    }
    public bool HasItem(int ID, int Amount)
    {
        int CurrentAmount = 0;
        foreach (InventorySlot slot in Inventory)
        {
            if (slot.GetID() == ID)
            {
                CurrentAmount += slot.GetAmount();
            }
        }
        return CurrentAmount >= Amount;
    }
    public void AddItem(Item InItem)
    {
        if (AreSlotsOccupied())
        {
            bool FoundSlot = false;
            foreach (InventorySlot slot in Inventory)
            {
                if (!slot.IsFull() && InItem.ID == slot.GetID() && InItem.Tags == slot.GetTags())
                {
                    slot.AddItem(InItem);
                    FoundSlot = true;
                }
            }
            if (!FoundSlot) throw new Exception("InventoryFull");
        }
        else 
        {
            bool FoundEmptySlot = false;
            int currentSlot = 0;
            while (!FoundEmptySlot)
            {
                if (Inventory[currentSlot].IsEmpty() || (Inventory[currentSlot].GetID() == InItem.ID && !Inventory[currentSlot].IsFull()))
                {
                    Inventory[currentSlot].AddItem(InItem);
                    FoundEmptySlot = true;
                }
                currentSlot++;
            }
        }
        LogInventory();
        UpdateUI();
    }
    public int FindSlotIndexWithItem(Item InItem)
    {
        for (int ItemSlot = 0; ItemSlot < Inventory.Length; ItemSlot++)
        {
            if (Inventory[ItemSlot].GetID() == InItem.ID)
            {
                return ItemSlot;
            }
        }
        return -1;
    }
    public void RemoveItem(Item InItem)
    {
        if (isEmpty())
        {
            throw new Exception("Inventory Empty");
        }
        int SlotToRemove = FindSlotIndexWithItem(InItem);
        Inventory[SlotToRemove].RemoveItem();
        UpdateUI();
    }


    public void LogInventory()
    {
        foreach (InventorySlot Slots in Inventory)
        {
            int ID = Slots.GetID();
            string Name = Slots.GetName();
            string Description = Slots.GetDescription();
            int MaxAmount = Slots.GetMaxAmount();
            int Amount = Slots.GetAmount();
            //string Tags = GetTagsDebug(Slots);
            Debug.Log($"ID: {ID}\nName: {Name}\nDescription: {Description}\nAmount: {Amount}\nMaxAmount: {MaxAmount}");
        }
    }
    public string GetTagsDebug(InventorySlot Slots)
    {
        string output = "";
        for (int i = 0; i < Slots.GetTags().Count; i++)
        {
            output += Slots.GetTags()[i] + " ";
        }
        return output;
    }
    void UpdateUI()
    {

    }
}
