using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public Ball _ball;
    [SerializeField] public PlayerScore _playerScore;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private PlayerMovement _player2Movement;
    [SerializeField] private TestAIMovement _player2AIMovement;
    [SerializeField] private UITimer _timer;
    [SerializeField] private Canvas _canvas;

    private void Awake()
    {
        _canvas.gameObject.SetActive(false);    
    }

    private void OnEnable()
    {
        _playerScore.onPointScored += OnPointScored;
    }

    void Start()
    {
        StartCoroutine(_timer.Countdown());
        StartCoroutine(ShowCanvasCoroutine());
        SetGameMode();
        
    }

    private IEnumerator ShowCanvasCoroutine()
    {
        yield return new WaitForSeconds(.1f);
        _canvas.gameObject.SetActive(true);
    }

    private void SetGameMode()
    {
        if (_gameSettings.IsPVP)
        {
            _player2Movement.enabled = true;
            _player2AIMovement.enabled = false;
            return;
        }

        _player2Movement.enabled = false;
        _player2AIMovement.enabled = true;
    }

    private void ResetGame(PlayerType playerType)
    {
        _ball.transform.position = new Vector2(0, 0);
        _ball.GoToRandomPosition(playerType);
    }

    private void OnPointScored(PlayerType playerType)
    {
        ResetGame(playerType);
    }

    private void OnDisable()
    {
        _playerScore.onPointScored -= OnPointScored;
    }
}
