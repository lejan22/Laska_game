using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moai : MonoBehaviour
{
    

    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
