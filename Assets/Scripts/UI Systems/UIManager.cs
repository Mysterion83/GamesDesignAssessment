using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameManager gm;
    [SerializeField]
    UIHotbar Hotbar;
    [SerializeField]
    GameObject PopupBox;
    [SerializeField]
    TextMeshProUGUI PopupBoxText;

    void Start()
    {
        PopupBox.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
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
        gm.FreezePlayer();
    }
    public void ClosePopup()
    {
        PopupBoxText.text = "";
        PopupBox.SetActive(false);
        gm.UnFreezePlayer();
    }
}
