using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControls : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;

    public static bool GameIsPause = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        mainMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
                

        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }

    }

    public void Pause()
    {
        mainMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;


        if (AudioListener.pause == false)
        {
            AudioListener.pause = true;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;

        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }
         
        SceneManager.LoadScene(0);
    }

    public void SelectionMenu()
    {
        Time.timeScale = 1f;
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }

        SceneManager.LoadScene(1);
    }

    public void RestartTrack()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        if (AudioListener.pause == true)
        {
            AudioListener.pause = false;
        }

        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 0) % 4);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 4);
    }

    public void ReturntoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
