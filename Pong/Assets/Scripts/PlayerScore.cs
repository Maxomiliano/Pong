using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] int _player1Score = 0;
    [SerializeField] int _player2Score = 0;
    [SerializeField] int _scoreAmount = 1;
    [SerializeField] TMP_Text _player1ScoreText;
    [SerializeField] TMP_Text _player2ScoreText;
    public event Action onPointScored;

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
        onPointScored?.Invoke();
        if (colliderID == "Player1Scores")
        {
            _player1Score += _scoreAmount;
            UpdatePlayerOneDisplay();
        }
        else if (colliderID == "Player2Scores")
        {
            _player2Score += _scoreAmount;
            UpdatePlayerTwoDisplay();
        }
    }
}
