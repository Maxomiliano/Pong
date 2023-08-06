using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    [SerializeField] PlayerScore playerScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //We want to add +1 to the player that touched the ball last
        if (collision != null) 
        {
            playerScore.AddScore(); //*Por qué esto no funciona?
            //FindObjectOfType<PlayerScore>().AddScore();
        }
        Destroy(collision.gameObject);
    }
}
