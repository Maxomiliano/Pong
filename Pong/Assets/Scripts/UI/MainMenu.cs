using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField] Button _playbutton;
    [SerializeField] Button _quitButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _creditsButton;

    [SerializeField] Window _playPanel;
    [SerializeField] Window _optionsPanel;
    [SerializeField] Window _creditsPanel;
    [SerializeField] Window _exitPanel;

    [SerializeField] EventSystem _eventSystem;
    [SerializeField] GameObject _selectedGameObject;

    //TODO: Implementar audio.

    private void Awake()
    {
        _playbutton.onClick.AddListener(ShowGameModePanel);
        _optionsButton.onClick.AddListener(ShowOptionsPanel);
        _creditsButton.onClick.AddListener(ShowCreditsPanel);
        _quitButton.onClick.AddListener(ShowExitPanel);
    }

    private void ShowGameModePanel()
    {
        _playPanel.OpenWindow();
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
    }

    private void ShowOptionsPanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _optionsPanel.OpenWindow();
    }

    private void ShowCreditsPanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _creditsPanel.OpenWindow();
    }

    private void ShowExitPanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _exitPanel.OpenWindow();
    }

    public void SelectFirstMenuItem()
    {
        _eventSystem.SetSelectedGameObject(_playbutton.gameObject);
    }
}
