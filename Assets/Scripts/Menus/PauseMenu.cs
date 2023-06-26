using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button restart;
    [SerializeField] Button menu;


    // Start is called before the first frame update
    void Start()
    {

        restart.onClick.AddListener(restartOnClick);
        menu.onClick.AddListener(menuOnClick);

    }

    void restartOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void menuOnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
