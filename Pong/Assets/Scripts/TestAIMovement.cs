using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAIMovement : MonoBehaviour
{
    [SerializeField] private GameObject ball; 
    public Rigidbody2D rbPaddle;
    public float paddleSpeed = 5.0f;

    void Start()
    {
        rbPaddle = GetComponent<Rigidbody2D>();
        Debug.Log("Activated AI Movement");
    }

    void FixedUpdate()
    {
        if (ball != null)
        {
            // Calculate direction towards the ball
            float direction = Mathf.Sign(ball.transform.position.y - transform.position.y);

            // Move the AI paddle towards the ball
            rbPaddle.velocity = new Vector2(0, direction * paddleSpeed);
        }
    }

    public void SetBall(GameObject newBall)
    {
        ball = newBall;
    }
}
