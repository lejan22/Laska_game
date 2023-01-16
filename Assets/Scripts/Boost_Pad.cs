using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_Pad : MonoBehaviour
{
    private PlayerController playercontroller;

    public float power = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        
        
        // Obtiene el rigidbody del GameObject
        Rigidbody playerRigidbody = other.gameObject.GetComponent<Rigidbody>();

        playerRigidbody.AddForce(Vector3.forward * power, ForceMode.Impulse);
    }
    
}
