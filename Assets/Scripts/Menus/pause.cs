using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    [SerializeField] GameObject pausemenu;
    bool is_paused = false;

    void Update()
    {
        pausemenu.SetActive(is_paused);
        Time.timeScale = is_paused ? 0 : 1;

        if (Input.GetKeyDown(KeyCode.Escape))
            is_paused = !is_paused;
    }
}
