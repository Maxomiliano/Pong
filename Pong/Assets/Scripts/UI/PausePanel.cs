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

    /*
    protected override void Awake()
    {
        base.Awake();
        _playerInputActions.UI.Pause.performed += OnPausePressed;
    }


    protected override void OnEnable()
    {
        base.OnEnable();
        m_resumeButton.onClick.AddListener(ClosePanel);
        //m_settingsButton.onClick.AddListener(ShowSettingsPanelButtonPress);
        m_mainMenuButton.onClick.AddListener(GameController.GoToMainMenu);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _playerInputActions.UI.Pause.performed -= OnPausePressed;
        m_resumeButton.onClick.RemoveListener(ClosePanel);
        //m_settingsButton.onClick.RemoveListener(ShowSettingsPanelButtonPress);
        m_mainMenuButton.onClick.RemoveListener(GameController.GoToMainMenu);
    }
    */
    private void Start()
    {
        _playerInputActions.UI.Pause.performed += OnPausePressed;
    }
    private void OnDestroy()
    {
        _playerInputActions.UI.Pause.performed -= OnPausePressed;
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        Debug.Log("Pause button pressed");
        if (WindowsManager.Instance.GetCurrentPanel() == this)
        {
            ClosePanel();
            Time.timeScale = 1;
        }
        else
        {
            OpenPanel();
            Time.timeScale = 0;
        }
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
