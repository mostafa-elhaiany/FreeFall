using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager
{
    public static float difficulty { get; private set; } = 2;

    public static void increase_difficulty()
    {
        difficulty = Mathf.Clamp(difficulty += 0.2f, 1, 10);

    }

    

}
