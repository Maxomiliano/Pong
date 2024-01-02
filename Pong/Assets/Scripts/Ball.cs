using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float _speed = 1f;
    public Rigidbody2D rigidBody;
    Vector3 lastVelocity;
    public static event Action<Ball> OnBallCreated = delegate { }; 

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        OnBallCreated(this);
        lastVelocity = rigidBody.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal); //Obtener Rigidbody y velocity de la tabla y con ese valor modifico la dirección de la pelota
        //direction *= rigidBody.velocity en valores Y 
        rigidBody.velocity = direction * Mathf.Max(speed, 0f);
    }

    //Evento public static OnBallCreated se pasa a sí mismo como parámetro y se suscribe el player2
}
