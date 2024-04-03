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

    public GameObject CloneBall;
    private Vector3 _ballInitialPosition;
    private Quaternion _ballInitialRotation;

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
        CreateBall();
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

    //Es recomendable no destruir la pelota.
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

    private void ResetGame(PlayerType playerType)
    {
        if (_ball != null)
        {
            CreateBall();
            _ball.GoToRandomPosition(playerType);
        }
        else if (CloneBall != null)
        {
            Destroy(CloneBall);
        }
    }

    void OnPointScored(PlayerType playerType)
    {
        ResetGame(playerType);
    }
}
