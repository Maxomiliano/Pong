using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] Button m_resumeButton;
    [SerializeField] Button m_settingsButton;
    [SerializeField] Button m_mainMenuButton;
    public static Action<bool> OnPausePanelStateChanged;
    public static Action OnShowSettingsPanelButtonPress;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        playerInputActions.UI.Pause.performed += OnPausePressed;
        playerInputActions.UI.Enable();
    }
    /*
    private void OnDisable()
    {
        playerInputActions.UI.Pause.performed -= OnPausePressed;
        playerInputActions.UI.Disable();
    }
    */

    private void Start()
    {
        m_resumeButton.onClick.AddListener(ResumeGame);
        m_settingsButton.onClick.AddListener(ShowSettingsPanelButtonPress);
        m_mainMenuButton.onClick.AddListener(GameController.GoToMainMenu);
        gameObject.SetActive(false);
    }

    private void ShowPauseMenuPanel()
    {
        if (gameObject.activeInHierarchy)
            return;
        OnPausePanelStateChanged?.Invoke(true);
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowSettingsPanelButtonPress()
    {
        OnShowSettingsPanelButtonPress?.Invoke();
        OptionsPanel.BackFromSettingsClick += BackFromSettingsPanel;
        gameObject.SetActive(false);
    }

    private void BackFromSettingsPanel()
    {
        OptionsPanel.BackFromSettingsClick -= BackFromSettingsPanel;
        ShowPauseMenuPanel();
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        OnPausePanelStateChanged?.Invoke(false);
        Time.timeScale = 1;
    }

    private void OnPausePressed(InputAction.CallbackContext context)
    {
        if (gameObject.activeInHierarchy)
        {
            ResumeGame();
        }
        else
        {
            ShowPauseMenuPanel();
        }
    }
}
