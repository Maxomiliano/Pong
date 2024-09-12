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
        _mainMenuButton.onClick.AddListener(GameController.GoToMainMenu);
        _settingsButton.onClick.AddListener(OpenSettingsWindow);
        SelectFirstMenuItem();
    }
    private void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(CloseWindow);
        _mainMenuButton.onClick.RemoveListener(GameController.GoToMainMenu);
        _settingsButton.onClick.RemoveListener(OpenSettingsWindow);
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
        _eventSystem.SetSelectedGameObject(_resumeButton.gameObject); // Selecciona el botón reanudar
    }
}
