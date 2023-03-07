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
    public Player_controller Playercontroller;

    private int totalItems = 0;
    private int itemsCollected = 0;
    public GameObject goal;

    private DataPersistance dataPersistence;


    [Header("USER INTERFACE")]
    
    public TextMeshProUGUI totalRoes;
    public TextMeshProUGUI collectedRoes;

    // Start is called before the first frame update
    void Start()
    {

        // Bloquea el uso del raton
        Cursor.lockState = CursorLockMode.Locked;
        
        dataPersistence = FindObjectOfType<DataPersistance>();


        Playercontroller = FindObjectOfType<Player_controller>();

        isGameOver = false;
        totalItems = GameObject.FindGameObjectsWithTag("Collectible").Length;
        totalRoes.text = totalItems.ToString();

        collectedRoes.text = itemsCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();


    }
    public void UpdateScore()
    {
        // Adds +1 to the total of roes collected
        itemsCollected++;

        // Actualiza el texto de las huevas recogidas
        collectedRoes.text = itemsCollected.ToString();

        
    }

    private void UpdateTimer()
    {
        // If GameOver is FALSE
        if (!isGameOver)
        {
            // Saves and ads deltaTime
            time += Time.deltaTime;

            //Turns time to minutes, seconds y miliseconds
            miliseconds = (int)((time - (int)time) * 100);
            seconds = (int)(time % 60);
            minutes = (int)(time / 60 % 60);

            // Turns text into the string of numbers
            timestamp.text = string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, miliseconds);
        }
    }

    private bool checkBestTime(string currentTime, string bestTime)
    {
        //  Regex pattern
        string pattern = "([0-9][0-9]):([0-9][0-9]).([0-9][0-9])";

    
        string[] currentTimeSplit = Regex.Split(currentTime, pattern);
        string[] bestTimeSplit = Regex.Split(bestTime, pattern);

        
        float currentMinutes = float.Parse(currentTimeSplit[1]);
        float bestMinutes = float.Parse(bestTimeSplit[1]);

       
        float currentSeconds = float.Parse(currentTimeSplit[2]);
        float bestSeconds = float.Parse(bestTimeSplit[2]);

      
        float currentMilisec = float.Parse(currentTimeSplit[3]);
        float bestMilisec = float.Parse(bestTimeSplit[3]);

       
        if (currentMinutes < bestMinutes)
        {
            return true;
        }

        
        if (currentMinutes == bestMinutes)
        {
            
            if (currentSeconds < bestSeconds)
            {
                return true;
            }

           
            if (currentSeconds == bestSeconds && currentMilisec <= bestMilisec)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    public void GameOver()
    {
        if(Playercontroller.currenthealth <= 0)
        {
            isGameOver = true;
            // saves the current time
            string currentTime = timestamp.text;

            
            if (!dataPersistence.HasKey("Best Time"))
            {
                
                dataPersistence.SetString("Best Time", "99:99.09");
            }

            
            string bestTime = dataPersistence.GetString("Best Time");

            // Saves current time
            dataPersistence.SetString("Current Time", currentTime);

           
            if (checkBestTime(currentTime, bestTime))
            {
                // save current time as best time
                dataPersistence.SetString("Best Time", currentTime);
            }
        }
    }
}
