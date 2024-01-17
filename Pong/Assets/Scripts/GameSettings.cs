using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Pong/GameSettings", order = 1)]
public class GameSettings : ScriptableObject
{
    [SerializeField] private bool isPVP = false;

    public bool IsPVP
    {
        get { return isPVP; }
        set { isPVP = value; }
    }
}
