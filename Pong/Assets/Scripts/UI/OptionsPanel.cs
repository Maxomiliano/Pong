using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsPanel : MonoBehaviour
{
    [SerializeField] Slider m_soundSlider;
    [SerializeField] Slider m_musicSlider;
    [SerializeField] Button m_backButton;
    public static Action<bool> OnSettingsPanelStateChanged;
    public static Action BackFromSettingsClick;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        PausePanel.OnShowSettingsPanelButtonPress += ShowSettingsPanel;
        MainMenu.OnShowSettingsPanelFromMainMenu += ShowSettingsPanel;
    }
    private void OnEnable()
    {
        playerInputActions.UI.Cancel.performed += OnBackButtonPressed;
        playerInputActions.UI.Enable();
    }

    private void Start()
    {
        //m_soundSlider.value = GameController.Instance.SFXValue;
        //m_musicSlider.value = GameController.Instance.MusicValue;
        //m_soundSlider.onValueChanged.AddListener(OnSFXValueChanged);
        //m_musicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        //m_backButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        m_backButton.onClick.AddListener(OnBackButtonClick);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        PausePanel.OnShowSettingsPanelButtonPress -= ShowSettingsPanel;
        MainMenu.OnShowSettingsPanelFromMainMenu -= ShowSettingsPanel;
    }

    private void ShowSettingsPanel()
    {
        if (gameObject.activeInHierarchy)
            return;
        //SFXController.Instance.PlayPopupOpensSFX();
        OnSettingsPanelStateChanged?.Invoke(true);
        gameObject.SetActive(true);
    }

    /*
    void OnSFXValueChanged(float value)
    {
        GameController.Instance.SFXValue = value;
    }

    void OnMusicValueChanged(float value)
    {
        GameController.Instance.MusicValue = value;
    }
    */

    private void OnBackButtonClick()
    {
        //SFXController.Instance.PlayPopupOpensSFX();
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            OnSettingsPanelStateChanged?.Invoke(false);
            BackFromSettingsClick?.Invoke();
        }
        else
        {
            ShowSettingsPanel();
        }
    }

    private void OnBackButtonPressed(InputAction.CallbackContext context)
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            OnSettingsPanelStateChanged?.Invoke(false);
            BackFromSettingsClick?.Invoke();
        }
        else
        {
            ShowSettingsPanel();
        }
    }
}
