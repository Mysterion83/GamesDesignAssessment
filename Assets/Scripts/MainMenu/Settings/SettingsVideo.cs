using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsVideo : MonoBehaviour
{
    [SerializeField]
    GameObject ResolutionDropDownGameObject;
    Dropdown ResolutionDropDown;

    Resolution[] Resolutions;
    // Start is called before the first frame update
    void Start()
    {
        ResolutionDropDown = ResolutionDropDownGameObject.GetComponent<Dropdown>();
        Resolutions = Screen.resolutions;

        List<string> ResolutionsInDropDown = new List<string>();

        ResolutionDropDown.ClearOptions();

        int DefaultResolution = 0;
        for (int i = 0; i < Resolutions.Length; i++)
        {
            string PossibleResolution = $"{Resolutions[i].width} x {Resolutions[i].height}";
            ResolutionsInDropDown.Add(PossibleResolution);

            if (Resolutions[i].width == Screen.currentResolution.width && Resolutions[i].height == Screen.currentResolution.height)
            {
                DefaultResolution = i;
            }
        }

        ResolutionDropDown.AddOptions(ResolutionsInDropDown);
        ResolutionDropDown.value = DefaultResolution;
        ResolutionDropDown.RefreshShownValue();
    }
    public void SetResolution(int ResolutionValue)
    {
        Resolution SelectedResolution = Resolutions[ResolutionValue];
        Screen.SetResolution(SelectedResolution.width, SelectedResolution.height, Screen.fullScreen);
    }
    public void ToggleFullScreen(bool FullScreen)
    {
        Screen.fullScreen = FullScreen;
    }
}
