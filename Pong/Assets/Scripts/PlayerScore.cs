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
    private const string PLAYER_1 = "Player1";
    private const string PLAYER_2 = "Player2";
    private const int WINING_SCORE = 10;
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
        if (colliderID == PLAYER_1)
        {
            onPointScored?.Invoke(PlayerType.User);
            _player1Score += _scoreAmount;
            UpdatePlayerOneDisplay();
        }
        else if (colliderID == PLAYER_2)
        {
            onPointScored?.Invoke(PlayerType.IA);
            _player2Score += _scoreAmount;
            UpdatePlayerTwoDisplay();
        }
        if (_player1Score == WINING_SCORE || _player2Score == WINING_SCORE)
        {
            GameController.Instance.PlayerWon(colliderID);
        }
    }
}
