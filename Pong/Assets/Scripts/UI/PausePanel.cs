using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PausePanel : Window
{
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] Window _settingsWindow;

    private void OnEnable()
    {
        _resumeButton.onClick.AddListener(CloseWindow);
        _mainMenuButton.onClick.AddListener(GameController.GoToMainMenu);
        _settingsButton.onClick.AddListener(OpenSettingsWindow);
    }
    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(CloseWindow);
        _mainMenuButton.onClick.RemoveListener(GameController.GoToMainMenu);
        _settingsButton.onClick.RemoveListener(OpenSettingsWindow);
    }

    
    private void OpenSettingsWindow()
    {
        //OptionsPanel.BackFromSettingsClick += BackFromSettingsPanel;
        //WindowsManager.Instance.GetCurrentPanel().CloseWindow();
        _settingsWindow.OpenWindow();
        
    }
    
    /*
    private void BackFromSettingsPanel()
    {
        OptionsPanel.BackFromSettingsClick -= BackFromSettingsPanel;
        WindowsManager.Instance.PopWindow();
    } 
    */
}
