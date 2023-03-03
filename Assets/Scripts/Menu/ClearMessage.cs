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

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Clearmessage()
    {

        _animator.Play("Clear_idle");

        yield return new WaitForSeconds(8);

        
        _animator.Play("Clear");
        Debug.Log("Henlo");
       int randomIndex = Random.Range(0, rankvoiceClips.Length);
        _audioS.PlayOneShot(rankvoiceClips[randomIndex], 1);

        yield return new WaitForSeconds(1);

        _audioS.PlayOneShot(Celebrationsong, 1);
    }
}
