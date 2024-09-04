using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _playbutton;
    [SerializeField] Button _quitButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _creditsButton;

    [SerializeField] Window _playPanel;
    [SerializeField] Window _optionsPanel;
    [SerializeField] Window _creditsPanel;

    [SerializeField] EventSystem _eventSystem;
    [SerializeField] GameObject _selectedGameObject;

    //public static Action OnShowSettingsPanelFromMainMenu;

    //TODO: Implementar audio.

    private void Awake()
    {
        _playbutton.onClick.AddListener(ShowGameModePanel);
        _optionsButton.onClick.AddListener(ShowOptionsPanel);
        _creditsButton.onClick.AddListener(ShowCreditsPanel);
        _quitButton.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void ShowGameModePanel()
    {
        _playPanel.OpenWindow();
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        //_eventSystem.SetSelectedGameObject(_playerVsPlayer.gameObject);
    }

    private void ShowOptionsPanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _optionsPanel.OpenWindow();
        //_eventSystem.SetSelectedGameObject(_optionsBackButton.gameObject);
    }

    private void ShowCreditsPanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _creditsPanel.OpenWindow();
        //_eventSystem.SetSelectedGameObject(_creditsBackButton.gameObject);
    }
}
