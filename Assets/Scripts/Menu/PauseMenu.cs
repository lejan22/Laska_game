using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;
    // Start is called before the first frame update

    //Starts with the pause menu closed
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame

    //Pressing esc makes the pause menu appear
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pausa el juego
            Pause();
        }
    }

    //Closes the pause menu and makes time go back to normal
    public void closePause()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);

    }

    //Restarts the level from the start
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level");
    }

    public void Pause()
    {
        //Makes the mouse usable, stops time and activates the pause menu
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            PausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            PausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;



        }

    }
}
