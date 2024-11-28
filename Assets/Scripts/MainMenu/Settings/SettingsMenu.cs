using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    GameObject GameplayTab;
    [SerializeField]
    GameObject VideoTab;
    [SerializeField]
    GameObject GraphicsTab;
    [SerializeField]
    GameObject AudioTab;

    SettingsTabs currentTab;


    // Start is called before the first frame update
    void Start()
    {
        SwitchTab(1);
    }
    public void SwitchTab(int InTab)
    {
        currentTab = (SettingsTabs)InTab;
        switch (currentTab)
        {
            case SettingsTabs.Gameplay:
                GameplayTab.SetActive(true);
                VideoTab.SetActive(false);
                GraphicsTab.SetActive(false);
                AudioTab.SetActive(false);
                break;
            case SettingsTabs.Video:
                GameplayTab.SetActive(false);
                VideoTab.SetActive(true);
                GraphicsTab.SetActive(false);
                AudioTab.SetActive(false);
                break;
            case SettingsTabs.Graphics:
                GameplayTab.SetActive(false);
                VideoTab.SetActive(false);
                GraphicsTab.SetActive(true);
                AudioTab.SetActive(false);
                break;
            case SettingsTabs.Audio:
                GameplayTab.SetActive(false);
                VideoTab.SetActive(false);
                GraphicsTab.SetActive(false);
                AudioTab.SetActive(true);
                break;
            default:
                break;
        }
    }
}
