using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PausePanel : Window
{
    [SerializeField] Button m_resumeButton;
    [SerializeField] Button m_settingsButton;
    [SerializeField] Button m_mainMenuButton;

    private void Start()
    {
        m_resumeButton.onClick.AddListener(ClosePanel);
        m_mainMenuButton.onClick.AddListener(GameController.GoToMainMenu);
        //m_settingsButton.onClick.AddListener(ShowSettingsPanelButtonPress);
    }
    private void OnDestroy()
    {
        m_resumeButton.onClick.RemoveListener(ClosePanel);
        m_mainMenuButton.onClick.RemoveListener(GameController.GoToMainMenu);
        //m_settingsButton.onClick.RemoveListener(ShowSettingsPanelButtonPress);
    }

    /*
    private void ShowSettingsPanelButtonPress()
    {
        OptionsPanel.BackFromSettingsClick += BackFromSettingsPanel;
        WindowsManager.Instance.GetCurrentPanel().ClosePanel();
    }

    private void BackFromSettingsPanel()
    {
        OptionsPanel.BackFromSettingsClick -= BackFromSettingsPanel;
        WindowsManager.Instance.PopWindow();
    }
    */
}
