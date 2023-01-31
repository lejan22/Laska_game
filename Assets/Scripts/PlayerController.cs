using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController charactercontroller;

    public float speed = 10f;
    public float turnspeed = 90;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    private void Awake()
    {
        charactercontroller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        charactercontroller.Move(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turnspeed * Time.deltaTime);
        
       



       
    }
}
