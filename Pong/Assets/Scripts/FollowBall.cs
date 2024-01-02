using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class FollowBall : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private Transform _pcPosition;
    [SerializeField] public float _speed;

    private void Awake()
    {
        Ball.OnBallCreated += FollowTarget;
    }

    void Start()
    {
        _ball = FindObjectOfType<Ball>().transform;
    }

    void Update()
    {
        //FollowTarget();   
    }

    //Hacer que este m�todo s�lo se triggeree cuando la bola est� del lado del P2??
    private void FollowTarget(Ball ball)
    {
        Vector3 ballY = _ball.position;
        ballY.x = _pcPosition.transform.position.x; //Es transform position.x porque es la direcci�n que queremos lockear


        if (_ball != null)
            _pcPosition.transform.position = Vector2.MoveTowards(_pcPosition.transform.position, ballY, _speed);
    }


    //OnBallCreated(ball ball)  
}
