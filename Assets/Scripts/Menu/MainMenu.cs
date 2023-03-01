using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject CreditsPanel;


    // Start is called before the first frame update
    void Start()
    {
        OptionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void options()
    {
        OptionPanel.SetActive(true);
    }

    public void closeOptions()
    {
        OptionPanel.SetActive(false);
    }

    public void credits()
    {
        CreditsPanel.SetActive(true);
    }

    public void closeCredits()
    {
        CreditsPanel.SetActive(false);
    }

}
