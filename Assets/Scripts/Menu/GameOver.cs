using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [Header("GAME COMPLETE")]
    public TextMeshProUGUI currentTime;
   // public TextMeshProUGUI bestTime;
    public TextMeshProUGUI Roes;

    [Header("EXTRAS")]
    private DataPersistance dataPersistence;

    void Start()
    {
        dataPersistence = FindObjectOfType<DataPersistance>();

        // Gets the time
        currentTime.text = dataPersistence.GetString("currentTime");
        
        Roes.text = dataPersistence.GetString("Roes");

        // Unlocks mouse
        Cursor.lockState = CursorLockMode.None;
    }
}
