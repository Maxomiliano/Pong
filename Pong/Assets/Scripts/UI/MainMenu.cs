using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button _playerVsPlayer;
    [SerializeField] Button _playerVsAI;
    [SerializeField] GameSettings _gameSettings;

    private void Awake()
    {
        _playerVsPlayer.onClick.AddListener(TogglePlayerVsPlayer);
        _playerVsAI.onClick.AddListener(TogglePlayerVsAI);
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
}
