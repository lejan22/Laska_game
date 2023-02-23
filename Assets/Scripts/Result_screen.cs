using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Result_screen : MonoBehaviour
{

    public AudioSource _audioS;
    public AudioClip[] rankvoiceClips;
    private int Roes;

    public TextMeshProUGUI collectedRoes;
    public TextMeshProUGUI TotalTime;
    public TextMeshProUGUI Rank;

    // Start is called before the first frame update
    void Start()
    {
        _audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rank()
    {
        if (Roes == 100)
        {
            Rank.text = "S"; 
            int randomIndex = Random.Range(0, rankvoiceClips.Length);
            _audioS.PlayOneShot(rankvoiceClips[randomIndex], 1);
        }
    }
}
