using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemSlot
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;

    public ItemSlot(int InID, string InName, string InDescription, Sprite InSprite)
    {
        id = InID;
        name = InName;
        description = InDescription;
        icon = InSprite;
    }
}
