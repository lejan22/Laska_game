using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timestamp;
    private bool isGameOver = false;
    private float time, minutes, seconds, miliseconds;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();

    }

    private void UpdateTimer()
    {
        // Si GameOver es FALSE
        if (!isGameOver)
        {
            // Guarda y suma deltatime
            time += Time.deltaTime;

            // Convierte time en minutos, segundos y milisegundos
            miliseconds = (int)((time - (int)time) * 100);
            seconds = (int)(time % 60);
            minutes = (int)(time / 60 % 60);

            // Cambia el texto con los valores formateados a un solo String
            timestamp.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, miliseconds);
        }
    }
    private bool checkBestTime(string currentTime, string bestTime)
    {
        // Patron del Regex
        string pattern = "([0-9][0-9]):([0-9][0-9]).([0-9][0-9])";

        // Guarda y divide el string en grupos con el pattern
        string[] currentTimeSplit = Regex.Split(currentTime, pattern);
        string[] bestTimeSplit = Regex.Split(bestTime, pattern);

        // Parsea el Grupo 01 de String a Float
        float currentMinutes = float.Parse(currentTimeSplit[1]);
        float bestMinutes = float.Parse(bestTimeSplit[1]);

        // Parsea el Grupo 02 de String a Float
        float currentSeconds = float.Parse(currentTimeSplit[2]);
        float bestSeconds = float.Parse(bestTimeSplit[2]);

        // Parsea el Grupo 03 de String a Float
        float currentMilisec = float.Parse(currentTimeSplit[3]);
        float bestMilisec = float.Parse(bestTimeSplit[3]);

        // Si currentMinutes es menor a bestMinutes
        if (currentMinutes < bestMinutes)
        {
            return true;
        }

        // Si currentMinutes es igual a bestMinutes
        if (currentMinutes == bestMinutes)
        {
            // Si currentSeconds es menor a bestSeconds
            if (currentSeconds < bestSeconds)
            {
                return true;
            }

            // Si currentSeconds es igual a bestSeconds y currentMilisec menor o igual a bestMilisec
            if (currentSeconds == bestSeconds && currentMilisec <= bestMilisec)
            {
                return true;
            }

            return false;
        }

        return false;
    }
}
