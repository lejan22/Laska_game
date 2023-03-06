using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sfx : MonoBehaviour
{
    public AudioClip[] jumpvoiceClips;
    public AudioSource _audioS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        jumpsfx();
        
    }

    void jumpsfx()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, jumpvoiceClips.Length);
            _audioS.PlayOneShot(jumpvoiceClips[randomIndex], 1);
        }
    }
}
