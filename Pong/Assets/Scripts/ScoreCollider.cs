using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollider : MonoBehaviour
{
    [SerializeField] PlayerScore playerScore;
    [SerializeField] string colliderID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null) 
        {
            playerScore.AddScore(colliderID); //Quién ganó el punto 
        }
        //collision.gameObject.SetActive(false);        
    }
}
