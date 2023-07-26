using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _ball;
    [SerializeField] float _xPush = 1f;
    [SerializeField] float _yPush = 1f;
    [SerializeField] float _speed = 1f;

    void Start()
    {
        ResetGame();
        GoToRandomPosition();   //After a player make a point, it should call GoToRandomPosition() again
    }

    void Update()
    {
        
    }
    private void GoToRandomPosition()
    {
        //At this point in code the ball goes to random position but only in the positive (1,1) axis
        float xRandom = Random.Range(0f, _xPush);
        float yRandom = Random.Range(0f, _yPush);
        _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(xRandom, yRandom * Time.deltaTime * _speed); //turn this into AddForce instead of Velocity
    }

    private void ResetGame()
    {
        Instantiate(_ball);
        _ball.SetActive(true);
    }

    /*
    private void GoToRandomPosition()
    {
        rigidBody.velocity = new Vector2(_xPush, _yPush);
        //float randomRangePosition = Random.Range(5f, 5f);
        //Vector2 newPosition = new Vector2(randomRangePosition, randomRangePosition * _speed * Time.deltaTime);


        //transform.position = newPosition;
        //transform.position = Vector2.MoveTowards(transform.position, newPosition, _speed * Time.deltaTime);
    }
    */
}
