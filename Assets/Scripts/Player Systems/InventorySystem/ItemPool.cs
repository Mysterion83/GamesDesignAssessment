using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPool
{
    public static readonly Item NullItem = new Item(-1, "Null", "Null", 1,new List<string>() {"Null"});
    public static readonly Item DebugItem = new Item(-2,"Debug Item","This is a Debug Item used for testing", 999, new List<string>() { "DebugItem" });
    public static readonly Item DebugItem2 = new Item(-3, "Debug Item2", "This is a Debug Item used for testing2", 999, new List<string>() { "DebugItem" });
    public static readonly Item DebugItem3 = new Item(-4, "Debug Item3", "This is a Debug Item used for testing3", 999, new List<string>() { "DebugItem" });
    public static readonly Item DebugItem4 = new Item(-5, "Debug Item4", "This is a Debug Item used for testing4", 999, new List<string>() { "DebugItem" });
    public static readonly Item ScientistKeycard = new Item(1, "Scientist Keycard", "A keycard given to low ranking scientists. Can open basic doors.", 1, new List<string>() { "UnlockLevel1Door" });

    public static Item GetItemViaID(int ID)
    {
        switch (ID)
        {
            case -1: return NullItem;
            case -2: return DebugItem;
            case -3: return DebugItem2;
            case -4: return DebugItem3;
            case -5: return DebugItem4;
            case 1: return new Item(1, "Scientist Keycard", "A keycard given to low ranking scientists. Can open basic doors.", 1, new List<string>() { "UnlockLevel1Door" });
            default: return NullItem;

        }
    }
}
