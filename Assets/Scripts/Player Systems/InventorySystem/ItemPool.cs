using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPool
{
    public static readonly Item NullItem = new Item(-1, "Null", "Null", 1,new List<string>() {"Null"});
    public static readonly Item DebugItem = new Item(1,"Debug Item","This is a Debug Item used for testing", 999, new List<string>() { "DebugItem" });
    public static readonly Item DebugItem2 = new Item(2, "Debug Item2", "This is a Debug Item used for testing2", 999, new List<string>() { "DebugItem" });
    public static readonly Item DebugItem3 = new Item(3, "Debug Item3", "This is a Debug Item used for testing3", 999, new List<string>() { "DebugItem" });
    public static readonly Item DebugItem4 = new Item(4, "Debug Item4", "This is a Debug Item used for testing4", 999, new List<string>() { "DebugItem" });

    public static Item GetItemViaID(int ID)
    {
        switch (ID)
        {
            case -1: return NullItem;
            case 1: return DebugItem;
            case 2: return DebugItem2;
            case 3: return DebugItem3;
            case 4: return DebugItem4;
            default: return NullItem;

        }
    }
}
