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


    void Start()
    {
        _ball.transform.position = Ball.FindObjectOfType<Transform>().position;
    }

    void Update()
    {
        FollowTarget();   
    }

    private void FollowTarget()
    {
        float currentSpeed = _speed * Time.deltaTime;
        if(_ball != null)
            _pcPosition.transform.position = Vector2.MoveTowards(_pcPosition.transform.position, _ball.transform.position, currentSpeed);
    }

}
