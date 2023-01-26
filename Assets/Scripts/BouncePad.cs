using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    private PlayerController playercontroller;

    public float power = 20f;
    

    private void OnTriggerStay(Collider other)
    {


        // Obtiene el rigidbody del GameObject
        Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();

        playerRigidbody.AddForce(Vector3.up * power, ForceMode.Impulse);
    }
}
