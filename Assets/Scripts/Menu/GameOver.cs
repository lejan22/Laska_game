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

        // Obtiene el mejor tiempo y el actual
        currentTime.text = dataPersistence.GetString("currentTime");
        //bestTime.text = dataPersistence.GetString("bestTime");
        Roes.text = dataPersistence.GetString("Roes");

        // Desbloquea el raton
        Cursor.lockState = CursorLockMode.None;
    }
}
