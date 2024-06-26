using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] EventSystem _eventSystem;

    [SerializeField] Button _playbutton;
    [SerializeField] GameObject _selectGameModePanel;
    [SerializeField] Button _playerVsPlayer;
    [SerializeField] Button _playerVsAI;

    [SerializeField] Button _quitButton;
    [SerializeField] Button _optionsButton;
    [SerializeField] Button _creditsButton;
    [SerializeField] Button _optionsBackButton;
    [SerializeField] Button _gameModeBackButton;
    [SerializeField] Button _creditsBackButton;
    [SerializeField] GameObject _optionsPanel;
    [SerializeField] GameObject _creditsPanel;
    [SerializeField] GameObject _mainMenuPanel;
    [SerializeField] GameSettings _gameSettings;
    [SerializeField] GameObject _title;
    [SerializeField] GameObject _selectedGameObject;

    //Ac� va el audio??

    private void Awake()
    {
        _playerVsPlayer.onClick.AddListener(TogglePlayerVsPlayer);
        _playerVsAI.onClick.AddListener(TogglePlayerVsAI);
        _quitButton.onClick.AddListener(Quit);
        _playbutton.onClick.AddListener(ShowGameModePanel);
        _optionsButton.onClick.AddListener(ShowOptionsPanel);
        _creditsButton.onClick.AddListener(ShowCreditsPanel);
        _optionsBackButton.onClick.AddListener(ShowMainMenuPanel);
        _creditsBackButton.onClick.AddListener(ShowMainMenuPanel);
        _gameModeBackButton.onClick.AddListener(ShowMainMenuPanel);
    }

    private void TogglePlayerVsPlayer()
    {
        _gameSettings.IsPVP = true;
        Play();
    }

    private void TogglePlayerVsAI()
    {
        
        _gameSettings.IsPVP = false;
        Play();
    }

    private void Play()
    {
        SceneManager.LoadScene("Play");
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void ShowGameModePanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _selectGameModePanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
        _creditsPanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _title.SetActive(true);
        _eventSystem.SetSelectedGameObject(_playerVsPlayer.gameObject);
    }

    private void ShowOptionsPanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _title.SetActive(true);
        _optionsPanel.SetActive(true);
        _mainMenuPanel.SetActive(false);
        _creditsPanel.SetActive(false);
        _selectGameModePanel.SetActive(false);
        _eventSystem.SetSelectedGameObject(_optionsBackButton.gameObject);
    }

    private void ShowCreditsPanel()
    {
        _selectedGameObject = EventSystem.current.currentSelectedGameObject;
        _creditsPanel.SetActive(true);
        _title.SetActive(false);
        _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(false);
        _selectGameModePanel.SetActive(false);
        _eventSystem.SetSelectedGameObject(_creditsBackButton.gameObject);
    }

    private void ShowMainMenuPanel()
    {
        EventSystem.current.SetSelectedGameObject( _selectedGameObject );
        _mainMenuPanel.SetActive(true);
        _optionsPanel.SetActive(false);
        _selectGameModePanel.SetActive(false);
        _creditsPanel.SetActive(false);
        _title.SetActive(true);
    }
}
