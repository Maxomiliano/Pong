using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryPanel : Window
{
    [SerializeField] Window _victoryPanel;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] TMP_Text _victoryText;
    [SerializeField] EventSystem _eventSystem;
    private const string PLAYER_1 = "Player1";
    private const string PLAYER_2 = "Player2";

    void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(GameController.Instance.GoToMainMenuFromVictoryPanel);
        _mainMenuButton.onClick.AddListener(SFXController.Instance.PlayButtonPressSFX);
        _eventSystem.SetSelectedGameObject(_mainMenuButton.gameObject);
    }
    void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(GameController.Instance.GoToMainMenuFromVictoryPanel);
        _mainMenuButton.onClick.RemoveListener(SFXController.Instance.PlayButtonPressSFX);
    }

    public void ShowVictoryPanel(string playerID)
    {
        SFXController.Instance.PlayPopupOpensSFX();
        MusicController.Instance.SetVictoryPanelTheme();
        if (playerID == PLAYER_1)
        {
            _victoryText.text = "Player 1 Wins";
        }
        else if (playerID == PLAYER_2)
        {
            _victoryText.text = "Player 2 Wins";
        }
        _victoryPanel.OpenWindow();
    }
}
