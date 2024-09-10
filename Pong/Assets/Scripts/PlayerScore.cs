using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlayerType
{
    User,
    IA
}

public class PlayerScore : MonoBehaviour
{
    private const string PLAYER_1_SCORES = "Player1Scores";
    private const string PLAYER_2_SCORES = "Player2Scores";
    [SerializeField] int _player1Score = 0;
    [SerializeField] int _player2Score = 0;
    [SerializeField] int _scoreAmount = 1;
    [SerializeField] TMP_Text _player1ScoreText;
    [SerializeField] TMP_Text _player2ScoreText;
    public event Action<PlayerType> onPointScored;

    private void Start()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        UpdatePlayerOneDisplay();
        UpdatePlayerTwoDisplay();
    }

    private void UpdatePlayerOneDisplay()
    {
        _player1ScoreText.text = _player1Score.ToString();
    }
    private void UpdatePlayerTwoDisplay()
    {
        _player2ScoreText.text = _player2Score.ToString();
    }

    public void AddScore(string colliderID)
    {
        if (colliderID == PLAYER_1_SCORES)
        {
            onPointScored?.Invoke(PlayerType.User);
            _player1Score += _scoreAmount;
            UpdatePlayerOneDisplay();
        }
        else if (colliderID == PLAYER_2_SCORES)
        {
            onPointScored?.Invoke(PlayerType.IA);
            _player2Score += _scoreAmount;
            UpdatePlayerTwoDisplay();
        }
        if (_player1Score == 10 || _player2Score == 10)
        {
            GameController.Instance.PlayerWon(colliderID);
        }
    }
}
