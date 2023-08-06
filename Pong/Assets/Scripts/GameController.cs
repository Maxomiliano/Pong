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

    private GameObject _cloneBall;

    private void OnEnable()
    {
        _playerScore.onPointScored += OnPointScored;
    }
    void Start()
    {
        //ResetGame();
        GoToRandomPosition();   //After a player make a point, it should call GoToRandomPosition() again
    }

    private void OnDisable()
    {
        _playerScore.onPointScored -= OnPointScored;
    }
    private void GoToRandomPosition()
    {
        if (_ball != null)
        {
            //UnityEngine.Random.insideUnitCircle
            float xRandom = UnityEngine.Random.Range(-1f, 1f); //X nunca puede ser 0
            float yRandom = UnityEngine.Random.Range(-1f, 1f); //Y nunca debería ser 0, salvo que la velocidad de Player modifique la reflexión de la pelota
            _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(xRandom, yRandom).normalized * _speed; //turn this into AddForce instead of Velocity
        }
    }

    private void ResetGame()
    {
        if (_ball != null)
        {
            _cloneBall = Instantiate(_ball);
            _cloneBall.SetActive(true);
            //Instantiate(_ball);
            //_ball.SetActive(true);
        }
    }

    void OnPointScored()
    {
        GoToRandomPosition();
        ResetGame();
    }
}
