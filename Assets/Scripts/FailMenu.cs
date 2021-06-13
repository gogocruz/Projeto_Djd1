using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject failMenu;
    
    private string currentScene;

    void Start()
    {
        failMenu.SetActive(false);
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        Timer timer = FindObjectOfType<Timer>();

        if (timer != null)
        {
            if (timer.StartCount)
            {
                if (timer.CurrentTime <= 0)
                {
                    PauseGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        failMenu.SetActive(true);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
