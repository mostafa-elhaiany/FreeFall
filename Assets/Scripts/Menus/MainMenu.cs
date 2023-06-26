using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;

    [SerializeField] TMPro.TextMeshProUGUI text;

    private void Start()
    {
        if(text is not null)
        {
            text.text = "High Score: " + GameManager.highscore;
        }
    }
    public void PlayGame()
    {
        // Load the first level. Make sure your game scene is added in the Build Settings to be loaded.
        SceneManager.LoadScene("Game_ez");
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
