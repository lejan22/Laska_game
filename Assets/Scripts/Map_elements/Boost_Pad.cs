using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Pad : MonoBehaviour
{
    private Player_controller playercontroller;

    public float power = 20f;
    
    private void OnTriggerStay(Collider other)
    {
        
        
        // Gets rigidbody of the GameObject
        Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();
        //Boosts the character
        playerRigidbody.AddForce(transform.forward * power, ForceMode.Impulse);
    }
    
}
