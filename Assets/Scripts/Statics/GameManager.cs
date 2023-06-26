using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager
{
    public static float current_difficulty { get; private set; } = 2;
    static float damped_difficulty= 1;
    static float difficulty = 2;

    static bool has_umbrella = false;

    public static void increase_difficulty()
    {
        difficulty = Mathf.Clamp(difficulty += 0.2f, 1, 10);
        damped_difficulty = Mathf.Clamp(damped_difficulty += 0.1f, 1, 7);
        difficulty = has_umbrella ? damped_difficulty : difficulty;
    }



    public static void got_umbrella()
    {
        current_difficulty = damped_difficulty;
    }
    public static void lost_umbrella()
    {
        current_difficulty = difficulty;
    }

}
