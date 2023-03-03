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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision othercollision)
    {
        if (othercollision.gameObject.CompareTag("Player"))
        {
            dataPersistence.SetString("currentTime", currentTime.text);
            dataPersistence.SetString("bestTime",bestTime.text);
            dataPersistence.SetString("Roes",Roes.text);
            // Desbloquea el raton
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("WinScene");
        }
    }
}
