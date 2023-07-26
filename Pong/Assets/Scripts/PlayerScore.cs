using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] int _player1Score = 0;
    [SerializeField] int _scoreAmount = 1;
    TMP_Text _playerScoreText;

    private void Start()
    {
        _playerScoreText = GetComponent<TMP_Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _playerScoreText.text = _player1Score.ToString();
    }

    public void AddScore()
    {
        _player1Score += _scoreAmount;
        UpdateDisplay();
    }
}
