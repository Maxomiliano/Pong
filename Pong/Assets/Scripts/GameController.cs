using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] float _xPush = 1f;
    [SerializeField] float _yPush = 1f;
    [SerializeField] float _speed = 1f;
    [SerializeField] public PlayerScore _playerScore;
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
        _ballInitialPosition = _ball.transform.position;
        //ResetGame();
        GoToRandomPosition();   //After a player make a point, it should call GoToRandomPosition() again
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
            _cloneBall = Instantiate(_ball, _ballInitialPosition, _ballInitialRotation);
            GoToRandomPosition();
            //_cloneBall.SetActive(true);
            //Instantiate(_ball);
            //_ball.SetActive(true);
        }
    }

    void OnPointScored()
    {
        ResetGame();
        //GoToRandomPosition();
    }
}
