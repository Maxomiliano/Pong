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
    public TestAIMovement _testAIMovement;

    private void OnEnable()
    {
        _playerScore.onPointScored += OnPointScored;
    }
    void Start()
    {
        CreateBall();
        GoToRandomPosition();   //After a player make a point, it should call GoToRandomPosition() again
        //ResetGame();
    }

    private void CreateBall()
    {
        _ballInitialPosition = _ball.transform.position;
        _ballInitialRotation = _ball.transform.rotation;
        _cloneBall = Instantiate(_ball, _ballInitialPosition, _ballInitialRotation);
        _testAIMovement.SetBall(_cloneBall); // Update the AI's reference to the new ball
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
