using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtons : MonoBehaviour
{

   
    
    //Goes back to the menu
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //Goes to the level
    public void Level()
    {
        SceneManager.LoadScene("Level");

    }
    //Exits the app
    public void Exiting()
    {
        Application.Quit();
    }

    
}
