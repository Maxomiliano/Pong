using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPanel : Window
{
    [SerializeField] Button _playerVsPlayer;
    [SerializeField] Button _playerVsPC;
    [SerializeField] Button _backButton;
    [SerializeField] GameSettings _gameSettings;
    [SerializeField] EventSystem _eventSystem;

    private void Start()
    {
        //_eventSystem.SetSelectedGameObject(_playerVsPlayer.gameObject);
    }

    private void OnEnable()
    {
        _playerVsPlayer.onClick.AddListener(TogglePlayerVsPlayer);
        _playerVsPC.onClick.AddListener(TogglePlayerVsAI);
        _backButton.onClick.AddListener(CloseWindow);
        _eventSystem.SetSelectedGameObject(_playerVsPlayer.gameObject);
    }

    private void OnDisable()
    {
        _playerVsPlayer.onClick.RemoveListener(TogglePlayerVsPlayer);
        _playerVsPC.onClick.RemoveListener(TogglePlayerVsAI);
        _backButton.onClick.RemoveListener(CloseWindow);
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
}
