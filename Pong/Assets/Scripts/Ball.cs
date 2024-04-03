using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] public GameController _gameController;
    [SerializeField] private Vector2 _yLimits;

    public Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GoToRandomPosition(PlayerType.User);
    }

    public void GoToRandomPosition(PlayerType playerType)
    {
        Vector2 initialDirection = Vector2.right;
        if (playerType == PlayerType.IA)
        {
            initialDirection = Vector2.left;
        }
        if (gameObject != null)
        {
            transform.position = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().velocity = GetRandomVectorInRange(_yLimits, initialDirection) * _speed;
            if (_gameController.CloneBall != null)
            {
                transform.position = Vector3.zero;
                gameObject.GetComponent<Rigidbody2D>().velocity = GetRandomVectorInRange(_yLimits, initialDirection) * _speed;
            }
        }
    }

    public Vector2 GetRandomVectorInRange(Vector2 yLimits, Vector2 direction)
    {
        var newDirection = direction + new Vector2(0, Random.Range(yLimits.x, yLimits.y));
        return newDirection;
    }
}