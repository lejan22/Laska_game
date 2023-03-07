using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Result_screen : MonoBehaviour
{

    public AudioSource _audioS;
    public AudioClip[] rankvoiceClips;
    public AudioClip Celebrationsong;
    private int Roes;

    public TextMeshProUGUI collectedRoes;
    public TextMeshProUGUI TotalTime;
    public TextMeshProUGUI Rank;

    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        _audioS = GetComponent<AudioSource>();
       
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    

    

   
}
