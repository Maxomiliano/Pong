using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    //At the start of the game GoToRandomPosition() from the middle of the screen
    //When colliding with player (or player2) it should bounce at a random location accordingly to physics
    //When colliding with top or botom edge of screen it should bounce that way also
    //Left and right wall must set their colliders to trigger. When the ball passes one of them, a sound should play and player score should increase (maybe this should be in playerscore.cs)
    //After a player make a point, it should call GoToRandomPosition() again


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
