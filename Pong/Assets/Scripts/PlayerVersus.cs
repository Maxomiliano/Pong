using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerVersus
{
    private static bool isPVP = false;

    public static bool IsPVP
    {
        get { return isPVP; }
        set { isPVP = value; }
    }
}
