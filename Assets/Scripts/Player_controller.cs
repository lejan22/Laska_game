using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public int lives = 3;
    public float speed = 30f;
    public float maxspeed = 30f;
    public float rotationSpeed = 300f;
    public float jumpForce = 2f;
    public float diveForce = 12f;
    public float stompForce = 15f;

    private float horizontalInput, verticalInput;
    private bool isJumping;

    public float jumpCutMultiplier = 9.8f;
    private int lastJumpTime;
    private bool jumpInputReleased;
    private bool canDive;

    

    private Rigidbody playerRigidbody;

    public LayerMask groundLayerMask;

    private float groundDistance = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();

        Diving();

        ActionStomp();
    }
    private void FixedUpdate()
    {
        
       //horizontalInput = Input.GetAxis("Horizontal");
       //verticalInput = Input.GetAxis("Vertical");

       //playerRigidbody.AddForce(Vector3.forward * speed * verticalInput, ForceMode.Force);
       //playerRigidbody.AddForce(Vector3.right * horizontalInput * speed);
       // transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
       // transform.Translate(Vector3.forward * speed * Time.deltaTime * horizontalInput);

       // transform.Rotate(Vector3.up * 100 * Time.deltaTime * horizontalInput);

        //Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
       //movementDirection.Normalize();

       // transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

       // if (movementDirection != Vector3.zero)
        {
          //  Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
          //  transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

            // Velocidad maxima del rigidbody del player
            //if (playerRigidbody.velocity.magnitude > maxspeed)
           // {
           //     // Mantiene a la velocidad maxima
               // playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxspeed;
          //  }


          //  Stop();
        }
       
    }
    //Salta
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            

            isJumping = true;

            canDive = true;
            
        }

        
    }
    public void OnJumpUp()
    {
        if(playerRigidbody.velocity.y > 0 && isJumping)
        {
            playerRigidbody.AddForce(Vector3.down * playerRigidbody.velocity.y * (1 - jumpCutMultiplier), ForceMode.Impulse);
            jumpInputReleased = true;
            lastJumpTime = 0;
        }
    }
    //Se lanza hacia adelante
    private void Diving()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !IsOnGround()&& canDive)
        {
            
            playerRigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
            playerRigidbody.AddForce(transform.forward * diveForce, ForceMode.VelocityChange);

            canDive = false;
        }

        

    }
    private void ActionStomp()
    {
        // Si presionas el click izquierdo del raton
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // Aplica una fuerza, un impulso vertical hacia abajo
            playerRigidbody.AddForce(Vector3.down * stompForce, ForceMode.Impulse);

          
        }
    }
    private void Stop()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerRigidbody.velocity =(Vector3.zero);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerRigidbody.velocity =(Vector3.zero);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerRigidbody.velocity= (Vector3.zero);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRigidbody.velocity = (Vector3.zero);
        }
    }
    private void characterRotation()
    {
        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime
, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private bool IsOnGround()
    {
        // Raycast hacia abajo con una distancia determinada
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitData, groundDistance, groundLayerMask);

        // Devuelve cualquier bool diferente a NULL
        return hitData.collider != null;

       
    }
     

}
