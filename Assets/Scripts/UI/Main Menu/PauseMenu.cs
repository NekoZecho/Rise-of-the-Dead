using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    GameObject Flashlight;
    GameObject GameOverHandler;

    private GameOver gameOver;
    void Start()
    {
        GameOverHandler = GameObject.FindGameObjectWithTag("GameOverHandler");
        gameOver = GameOverHandler.GetComponent<GameOver>();
        GetComponent<Canvas>().enabled = false;
        Flashlight = GameObject.FindGameObjectWithTag("Flashlight");
    }


    void Update()
    {
        //If you press the escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }

    }

    public void Resume()
    {
        GetComponent<Canvas>().enabled = false;
        //reset the time scale
        Time.timeScale = 1;
        Flashlight.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        GetComponent<Canvas>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        gameOver.GameOverScreen();
    }
    public void Pause()
    {
        //make the pause menu visible
        GetComponent<Canvas>().enabled = true;
        //also, stop the game from playing
        Time.timeScale = 0;
        Flashlight.SetActive(false);
    }
    
}