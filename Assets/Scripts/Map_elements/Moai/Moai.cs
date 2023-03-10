using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moai : MonoBehaviour
{

    //Useful for making the player move with the top of the moai head
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
