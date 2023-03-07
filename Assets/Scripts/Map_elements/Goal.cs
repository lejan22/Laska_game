using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Goal : MonoBehaviour
{
    [Header("GAME COMPLETE")]
    public TextMeshProUGUI currentTime;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI Roes;

    private DataPersistance dataPersistence;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        dataPersistence = FindObjectOfType<DataPersistance>();
    }


    private void OnCollisionEnter(Collision othercollision)
    {
        if (othercollision.gameObject.CompareTag("Player"))
        {
            dataPersistence.SetString("currentTime", currentTime.text);
            dataPersistence.SetString("bestTime",bestTime.text);
            dataPersistence.SetString("Roes",Roes.text);
            //Unlocks mouse
            Cursor.lockState = CursorLockMode.None;

            //Sends you to the winning scene
            SceneManager.LoadScene("WinScene");
        }
    }
}
