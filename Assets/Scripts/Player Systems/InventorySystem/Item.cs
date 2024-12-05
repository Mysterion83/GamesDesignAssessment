using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
public struct Item
{
    public int ID;
    public string Name;
    public string Description;
    public int MaxAmount;
    public List<ItemTags> Tags;
    public Sprite ItemImage;

    public Item(int InID, string InName, string InDescription, int InMaxAmount, List<ItemTags> InTags, Sprite InSprite)
    {
        ID = InID;
        Name = InName;
        Description = InDescription;
        MaxAmount = InMaxAmount;
        Tags = InTags;
        ItemImage = InSprite;
    }
    public Item(Item InItem)
    {
        ID = InItem.ID;
        Name = InItem.Name;
        Description = InItem.Description;
        MaxAmount = InItem.MaxAmount;
        Tags = InItem.Tags;
        ItemImage = InItem.ItemImage;
    }
}
