using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAIMovement : MonoBehaviour
{
    public Rigidbody2D rbPaddle;
    private GameObject ball; 
    public float paddleSpeed = 5.0f;

    void Start()
    {
        rbPaddle = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
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
