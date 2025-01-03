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
            case SettingsTabs.Audio:
                AudioTab.SetActive(true);
                break;
            default:
                break;
        }
    }
}
