using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject CreditsPanel;
    public GameObject ControlsPanel;


    // Start is called before the first frame update
    void Start()
    {
        OptionPanel.SetActive(false);
    }

   
    //Opens the options menu
    public void options()
    {
        OptionPanel.SetActive(true);
    }
    //Closes the options menu
    public void closeOptions()
    {
        OptionPanel.SetActive(false);
    }
    //Opens the credits menu
    public void credits()
    {
        CreditsPanel.SetActive(true);
    }
    //Closes the credits menu
    public void closeCredits()
    {
        CreditsPanel.SetActive(false);
    }
    //Opens the controls menu
    public void Controls()
    {
        ControlsPanel.SetActive(true);
    }
    //Closes the controls menu
    public void closeControls()
    {
        ControlsPanel.SetActive(false);
    }
    //Closes the app
    public void Buhbye()
    {
        Application.Quit();
    }
}
