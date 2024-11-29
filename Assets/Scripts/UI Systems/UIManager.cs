using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    UIHotbar Hotbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InventoryUpdate(InventorySlot[] slots)
    {
        Hotbar.HotbarUpdate(slots);
    }
    public void CurrentSlotUpdate(int slot, string InName, string InDescription)
    {
        Hotbar.CurrentSlotUpdate(slot,InName,InDescription);
    }
}
