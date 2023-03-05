using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Pausa el juego
            Pause();
        }
    }

    public void closePause()
    {
        PausePanel.SetActive(false);

    }

    public void Pause()
    {
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
