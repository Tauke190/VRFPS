using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic
{
    public static float deltaMultiplier = 60f;

    public static float deltaMod()
    {
        return deltaMultiplier * Time.deltaTime;
    }
}
