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
        //charactercontroller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        charactercontroller.Move(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turnspeed * Time.deltaTime);
        
        // float horizontal = Input.GetAxisRaw("Horizontal");

        // float vertical = Input.GetAxisRaw("Vertical");

        // Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;



        /*if(direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * speed * Time.deltaTime); 

        }
        */
    }
}
