using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] public GameController _gameController;

    public Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GoToRandomPosition();
    }

    public void GoToRandomPosition()
    {
        if (gameObject != null)
        {
            transform.position = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * _speed;
            if (_gameController.CloneBall != null)
            {
                transform.position = Vector3.zero;
                gameObject.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * _speed;
            }
        }
    }
}
