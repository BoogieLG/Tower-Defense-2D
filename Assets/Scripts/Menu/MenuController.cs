using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    enum Screen
    {
        Main,
        Settings,
        Loading
    }

    public CanvasGroup MainScreen;
    public CanvasGroup SettingsScreen;

    private void Start()
    {
        SetCurrentScreen(Screen.Main);
        AudioSingletone.instance.SwitchMusic("MenuMusic");
    }

    void SetCurrentScreen (Screen screen)
    {
        Utility.SetCanvasGroupEnabled(MainScreen, screen == Screen.Main);
        Utility.SetCanvasGroupEnabled(SettingsScreen, screen == Screen.Settings);
    }

    public void StartGame()
    {
        AudioSingletone.instance.PlaySound("UIPressed");
        SetCurrentScreen(Screen.Loading);
        LoadingScreen.instance.LoadScene("Level-1");
    }

    public void OpenSettingMenu()
    {
        AudioSingletone.instance.PlaySound("UIPressed");
        SetCurrentScreen(Screen.Settings);
    }
    public void CloseSettingMenu()
    {
        AudioSingletone.instance.PlaySound("UIPressed");
        SetCurrentScreen(Screen.Main);
    }

    public void ExitGame()
    {
        AudioSingletone.instance.PlaySound("UIPressed");
        Application.Quit();
    }
}
