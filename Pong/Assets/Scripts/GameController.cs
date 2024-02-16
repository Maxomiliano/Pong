using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public Ball _ball;
    [SerializeField] public PlayerScore _playerScore;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private PlayerMovement _player2Movement;
    [SerializeField] private TestAIMovement _player2AIMovement;

    public GameObject CloneBall;
    private Vector3 _ballInitialPosition;
    private Quaternion _ballInitialRotation;

    private void OnEnable()
    {
        _playerScore.onPointScored += OnPointScored;
    }
    void Start()
    {
        SetGameMode();
        CreateBall();
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

    private void CreateBall()
    {
        _ballInitialPosition = _ball.transform.position;
        _ballInitialRotation = _ball.transform.rotation;
        CloneBall = Instantiate(_ball.gameObject, _ballInitialPosition, _ballInitialRotation);
        _player2AIMovement.SetBall(CloneBall); // Update the AI's reference to the new ball
    }

    private void OnDisable()
    {
        _playerScore.onPointScored -= OnPointScored;
    }

    private void ResetGame()
    {
        if (_ball != null)
        {
            CreateBall();
            _ball.GoToRandomPosition();
        }
        else if (CloneBall != null)
        {
            Destroy(CloneBall);
        }
    }

    void OnPointScored()
    {
        ResetGame();
    }
}
