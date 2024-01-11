using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Toggle : MonoBehaviour
{
    [SerializeField] GameObject _player2;

    public void PlayerVersusPlayer()
    {
        _player2.GetComponent<PlayerMovement>().enabled = true;
        //_player2.GetComponent<TestAIMovement>().enabled = false;
    }

    public void PlayerVersusAI()
    {
        _player2.GetComponent<PlayerMovement>().enabled = false;
        //_player2.GetComponent<TestAIMovement>().enabled = true;
    }
}
