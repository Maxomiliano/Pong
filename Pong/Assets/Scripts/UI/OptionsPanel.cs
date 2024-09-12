using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OptionsPanel : Window
{
    [SerializeField] Slider _soundSlider;
    [SerializeField] Slider _musicSlider;
    [SerializeField] Button _backButton;
    [SerializeField] EventSystem _eventSystem;

    private void OnEnable()
    {
        _eventSystem.SetSelectedGameObject(_soundSlider.gameObject);
        _backButton.onClick.AddListener(CloseWindow);
    }

    private void OnDisable()
    {
        _backButton.onClick.RemoveListener(CloseWindow);
    }

    private void Start()
    {
        _soundSlider.value = GameController.Instance.SFXValue;
        _musicSlider.value = GameController.Instance.MusicValue;
        _soundSlider.onValueChanged.AddListener(OnSFXValueChanged);
        _musicSlider.onValueChanged.AddListener(OnMusicValueChanged);
        //m_backButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
    }
    void OnSFXValueChanged(float value)
    {
        GameController.Instance.SFXValue = value;
    }

    void OnMusicValueChanged(float value)
    {
        GameController.Instance.MusicValue = value;
    }

    public override void CloseWindow()
    {
        _eventSystem.SetSelectedGameObject(null);
        DeselectCurrentButton();
        base.CloseWindow();
        PausePanel currentPanel = WindowsManager.Instance.GetCurrentPanel() as PausePanel;
        if (currentPanel != null)
        {
            currentPanel.SelectFirstMenuItem();
        }
    }
    private void DeselectCurrentButton()
    {
        SelectableArrow arrowComponent = _backButton.GetComponent<SelectableArrow>();
        if (arrowComponent != null)
        {
            arrowComponent.HideArrow();
        }
        _eventSystem.SetSelectedGameObject(_soundSlider.gameObject);
    }
}
