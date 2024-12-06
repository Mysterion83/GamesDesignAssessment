using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTabsManager : MonoBehaviour
{
    GameManager gm;

    [SerializeField]
    MainMenuTabs CurrentTab;

    [Header("MenuObjects")]
    [SerializeField]
    public GameObject MainMenu;
    [SerializeField]
    public GameObject Settings;
    [SerializeField]
    public GameObject Credits;
    [SerializeField]
    public GameObject Controls;

    [Header("Settings")]
    public string tmp;

    // Start is called before the first frame update
    void Start()
    {
        CurrentTab = MainMenuTabs.MainMenu;
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    public void ChangeMenu(int IntTabToChange)
    {
        MainMenuTabs TabToChange = (MainMenuTabs)IntTabToChange;
        CurrentTab = TabToChange;

        switch (TabToChange)
        {
            case MainMenuTabs.MainMenu:
                MainMenu.SetActive(true);
                Settings.SetActive(false);
                Credits.SetActive(false);
                Controls.SetActive(false);
                break;
            case MainMenuTabs.PlayGame:
                gm.PlayGame();
                break;
            case MainMenuTabs.Settings:
                MainMenu.SetActive(false);
                Settings.SetActive(true);
                Credits.SetActive(false);
                Controls.SetActive(false);
                break;
            case MainMenuTabs.Credits:
                MainMenu.SetActive(false);
                Settings.SetActive(false);
                Credits.SetActive(true);
                Controls.SetActive(false);
                break;
            case MainMenuTabs.Controls:
                MainMenu.SetActive(false);
                Settings.SetActive(false);
                Credits.SetActive(false);
                Controls.SetActive(true);
                break;
            case MainMenuTabs.Quit:
                gm.QuitGame();
                break;
        }


    }
}
