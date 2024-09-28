using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public struct Item
{
    public int ID;
    public string Name;
    public string Description;
    public int MaxAmount;
    public List<string> Tags;

    public Item(int InID, string InName, string InDescription, int InMaxAmount, List<string>InTags)
    {
        ID = InID;
        Name = InName;
        Description = InDescription;
        MaxAmount = InMaxAmount;
        Tags = InTags;
    }
    public Item(Item InItem)
    {
        ID = InItem.ID;
        Name = InItem.Name;
        Description = InItem.Description;
        MaxAmount = InItem.MaxAmount;
        Tags = InItem.Tags;
    }
}
