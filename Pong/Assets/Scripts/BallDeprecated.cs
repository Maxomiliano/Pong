/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDeprecated : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] public GameController _gameController;

    public Rigidbody2D rigidBody;
    //Vector3 lastVelocity;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GoToRandomPosition();
    }

    void FixedUpdate()
    {
        //lastVelocity = rigidBody.velocity;        
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal); //Obtener Rigidbody y velocity de la tabla y con ese valor modifico la direcci�n de la pelota
        //direction *= rigidBody.velocity; //en valores Y 
        rigidBody.velocity = direction * Mathf.Max(lastVelocity.magnitude, 0f);
    }

    public void GoToRandomPosition()
    {
        //float xRandom = UnityEngine.Random.Range(-1f, 1f); //X nunca puede ser 0
        //float yRandom = UnityEngine.Random.Range(-1f, 1f); //Y nunca deber�a ser 0, salvo que la velocidad de Player modifique la reflexi�n de la pelota
        if (gameObject != null)
        {
            transform.position = Vector3.zero;
            gameObject.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * _speed;
            //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(xRandom, yRandom).normalized * _speed; //turn this into AddForce instead of Velocity
            //rigidBody.AddForce(new Vector2(xRandom, yRandom) * _speed);
            if (_gameController.CloneBall != null)
            {
                //_gameController.CloneBall.GetComponent<Rigidbody2D>().velocity = new Vector2(xRandom, yRandom).normalized * _speed;
                //rigidBody.AddForce(new Vector2(xRandom, yRandom) * _speed);
                transform.position = Vector3.zero;
                gameObject.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * _speed;
            }
        }
    }
}
*/
