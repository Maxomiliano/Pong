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
    public event Action onPointScored;

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
        onPointScored?.Invoke(); //Don't forget to call the Invoke method where you want the action to be called
        _player1Score += _scoreAmount;
        UpdateDisplay();
    }
}
