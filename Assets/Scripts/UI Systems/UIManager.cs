using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    UIHotbar Hotbar;
    [SerializeField]
    GameObject PopupBox;
    [SerializeField]
    TextMeshProUGUI PopupBoxText;
    // Start is called before the first frame update
    void Start()
    {
        PopupBox.SetActive(false);
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
    public void DisplayPopup(string Text)
    {
        PopupBox.SetActive(true);
        PopupBoxText.text = Text;
    }
    public void ClosePopup()
    {
        Debug.Log("Closing Pop-up");
        PopupBoxText.text = "";
        PopupBox.SetActive(false);
    }
}
