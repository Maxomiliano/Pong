using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] GameObject _ball;
    [SerializeField] public PlayerScore _playerScore;
    [SerializeField] private PlayerMovement _player2Movement;
    [SerializeField] private TestAIMovement _player2AIMovement;
    [SerializeField] private float _xPush = 1f;
    [SerializeField] private float _yPush = 1f;
    [SerializeField] private float _speed = 1f;
    //[SerializeField] Vector3 _lastPosition;

    private GameObject _cloneBall;
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
        GoToRandomPosition();
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
        _cloneBall = Instantiate(_ball, _ballInitialPosition, _ballInitialRotation);
        _player2AIMovement.SetBall(_cloneBall); // Update the AI's reference to the new ball
    }

    private void OnDisable()
    {
        _playerScore.onPointScored -= OnPointScored;
    }
    private void GoToRandomPosition()
    {
        float xRandom = UnityEngine.Random.Range(-1f, 1f); //X nunca puede ser 0
        float yRandom = UnityEngine.Random.Range(-1f, 1f); //Y nunca debería ser 0, salvo que la velocidad de Player modifique la reflexión de la pelota
        if (_ball != null)
        {
            //UnityEngine.Random.insideUnitCircle
            _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(xRandom, yRandom).normalized * _speed; //turn this into AddForce instead of Velocity
            if (_cloneBall != null)
                _cloneBall.GetComponent<Rigidbody2D>().velocity = new Vector2(xRandom, yRandom).normalized * _speed;
        }
    }

    private void ResetGame()
    {
        if (_ball != null)
        {
            CreateBall();
            GoToRandomPosition();
        }
        else if (_cloneBall != null)
        {
            Destroy(_cloneBall);
        }
    }

    void OnPointScored()
    {
        ResetGame();
    }
}
