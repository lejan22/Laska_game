using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_sfx : MonoBehaviour
{
    public AudioClip[] jumpvoiceClips;
    public AudioClip[] attackvoiceClips;
    public AudioSource _audioS;
   
   

    // Update is called once per frame
    void Update()
    {
        jumpsfx();
        attacksfx();
    }

    //Plays a random sfx when Laska jumps
    void jumpsfx()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int randomIndex = Random.Range(0, jumpvoiceClips.Length);
            _audioS.PlayOneShot(jumpvoiceClips[randomIndex], 1);
        }
    }
    //Plays a random sfx when Laska attacks

    void attacksfx()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            int randomIndex = Random.Range(0, attackvoiceClips.Length);
            _audioS.PlayOneShot(attackvoiceClips[randomIndex], 1);
        }
    }
}
