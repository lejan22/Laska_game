using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMessage : MonoBehaviour
{

    public AudioSource _audioS;
    public AudioClip[] rankvoiceClips;
    public AudioClip Celebrationsong;
    public Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
       

        StartCoroutine(Clearmessage());
    }

 

    IEnumerator Clearmessage()
    {
        //Animation of hthe idle
        _animator.Play("Clear_idle");

        //Wait for the first song to finish
        yield return new WaitForSeconds(8);

        //Plays the animation of the message saying clear
        _animator.Play("Clear");

       //Plays a random voice
       int randomIndex = Random.Range(0, rankvoiceClips.Length);
        _audioS.PlayOneShot(rankvoiceClips[randomIndex], 1);
        //Waits a second
        yield return new WaitForSeconds(1);
        //Plays the ending song
        _audioS.PlayOneShot(Celebrationsong, 1);
    }
}
