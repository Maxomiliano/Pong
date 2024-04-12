using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] Button m_resumeButton;
    [SerializeField] Button m_settingsButton;
    [SerializeField] Button m_mainMenuButton;
    public static Action<bool> OnPausePanelStateChanged;
    public static Action OnShowSettingsPanelButtonPress;

    private void Start()
    {
        m_resumeButton.onClick.AddListener(ResumeGame);
        //m_resumeButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        m_settingsButton.onClick.AddListener(ShowSettingsPanelButtonPress);
        //m_settingsButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        m_mainMenuButton.onClick.AddListener(GameController.GoToMainMenu);
        //m_mainMenuButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        //m_mainMenuButton.onClick.AddListener(ResumeGame);
        gameObject.SetActive(false);
    }

    //GameController press P
    private void ShowPauseMenuPanel()
    {
        if (gameObject.activeInHierarchy)
            return;
        //SFXController.Instance.PlayPopupOpensSFX();
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

    //GameController press ESC
    public void ResumeGame()
    {
        //SFXController.Instance.PlayPopupOpensSFX();
        gameObject.SetActive(false);
        OnPausePanelStateChanged?.Invoke(false);
        Time.timeScale = 1;
    }
}
