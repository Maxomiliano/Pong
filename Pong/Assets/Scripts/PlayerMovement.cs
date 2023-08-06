using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
    }

    /*
    private void FixedUpdate()
    {
        _rigidbody.velocity = _movementInput * _movementSpeed; // * Time.DeltaTime ?
    }
    */


    private void OnMove(InputValue inputValue)
    {
        _movementInput = inputValue.Get<Vector2>();
    }

    private void Movement()
    {
        _rigidbody.velocity = _movementInput * _movementSpeed; // * Time.DeltaTime ?
    }
}