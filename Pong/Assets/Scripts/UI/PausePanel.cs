using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PausePanel : Window
{
    [SerializeField] Button _resumeButton;
    [SerializeField] Button _settingsButton;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] Window _settingsWindow;
    [SerializeField] EventSystem _eventSystem;

    private void OnEnable()
    {
        _resumeButton.onClick.AddListener(CloseWindow);
        _resumeButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        _mainMenuButton.onClick.AddListener(GameController.GoToMainMenu);
        _mainMenuButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        _settingsButton.onClick.AddListener(OpenSettingsWindow);
        _settingsButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        SelectFirstMenuItem();
    }
    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(CloseWindow);
        _resumeButton.onClick.RemoveListener(SFXController.Instance.PlayButtonPressSFX);
        _mainMenuButton.onClick.RemoveListener(GameController.GoToMainMenu);
        _mainMenuButton.onClick.RemoveListener(SFXController.Instance.PlayButtonPressSFX);
        _settingsButton.onClick.RemoveListener(OpenSettingsWindow);
        _settingsButton.onClick.RemoveListener(SFXController.Instance.PlayButtonPressSFX);
    }
    
    private void OpenSettingsWindow()
    {
        _settingsWindow.OpenWindow();
        SelectableArrow arrowComponent = _settingsButton.GetComponent<SelectableArrow>();
        if (arrowComponent != null)
        {
            arrowComponent.HideArrow();
        }
    }
    public override void CloseWindow()
    {
        DeselectCurrentButton();
        base.CloseWindow();
    }
    private void DeselectCurrentButton()
    {
        SelectableArrow arrowComponent = _settingsButton.GetComponent<SelectableArrow>();
        if (arrowComponent != null)
        {
            arrowComponent.HideArrow();
        }
        _eventSystem.SetSelectedGameObject(_resumeButton.gameObject);
    }
    public void SelectFirstMenuItem()
    {
        _eventSystem.SetSelectedGameObject(null);
        _eventSystem.SetSelectedGameObject(_resumeButton.gameObject);
    }
}
