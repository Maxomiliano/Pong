using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] Slider m_soundSlider;
    [SerializeField] Slider m_musicSlider;
    [SerializeField] TMP_Text m_soundText;
    [SerializeField] TMP_Text m_musicText;
    [SerializeField] Button m_backButton;
    public static Action<bool> OnSettingsPanelStateChanged;
    public static Action BackFromSettingsClick;

    private void Awake()
    {
        PausePanel.OnShowSettingsPanelButtonPress += ShowSettingsPanel;
        MainMenu.OnShowSettingsPanelFromMainMenu += ShowSettingsPanel;
    }

    private void Start()
    {
        m_soundSlider.value = GameController.Instance.SFXValue;
        m_musicSlider.value = GameController.Instance.MusicValue;
        m_soundSlider.onValueChanged.AddListener(OnSFXValueChanged);
        m_musicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        m_backButton.onClick.AddListener(OnBackButtonClick);
        //m_backButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PausePanel.OnShowSettingsPanelButtonPress -= ShowSettingsPanel;
        //MainMenuCanvas.OnShowSettingsPanelFromMainMenu -= ShowSettingsPanel;
    }

    private void ShowSettingsPanel()
    {
        if (gameObject.activeInHierarchy)
            return;
        //SFXController.Instance.PlayPopupOpensSFX();
        OnSettingsPanelStateChanged?.Invoke(true);
        gameObject.SetActive(true);
    }

    void OnSFXValueChanged(float value)
    {
        GameController.Instance.SFXValue = value;
    }

    void OnMusicValueChanged(float value)
    {
        GameController.Instance.MusicValue = value;
    }


    void OnBackButtonClick()
    {
        //SFXController.Instance.PlayPopupOpensSFX();
        gameObject.SetActive(false);
        BackFromSettingsClick?.Invoke();
    }
}
