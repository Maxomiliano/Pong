using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryPanel : Window
{
    [SerializeField] Window _victoryPanel;
    [SerializeField] Button _mainMenuButton;
    [SerializeField] TMP_Text _victoryText;

    void OnEnable()
    {
        _mainMenuButton.onClick.AddListener(GameController.Instance.GoToMainMenuFromVictoryPanel);
    }
    void OnDisable()
    {
        _mainMenuButton.onClick.RemoveListener(GameController.Instance.GoToMainMenuFromVictoryPanel);
    }

    public void ShowVictoryPanel(string playerID)
    {
        if (playerID == "Player1Scores")
        {
            _victoryText.text = "Player 1 Wins!";
        }
        else if (playerID == "Player2Scores")
        {
            _victoryText.text = "Player 2 Wins!";
        }
        _victoryPanel.OpenWindow();
        //Time.timeScale = 0;
    }
}
