using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    [Header("Life")]
    public int MaxHealth = 3;
    public int currenthealth = 3;
    public Healthbar healthBar;

    [Header("Speed")]
    public float speed = 30f;
    public float maxspeed = 30f;

    [Header("Jump")]
    public float jumpForce = 210.0f;
    private float verticalVelocity;
    private float gravity = 80.0f;
    
    public float diveForce = 12f;
    public float stompForce = 15f;

    [Header("controller")]
    private float horizontalInput, verticalInput;
    private bool isJumping;

    public float jumpCutMultiplier = 9.8f;
    private int lastJumpTime;
    private bool jumpInputReleased;
    private bool canDive;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    [Header("elements")]
    private Rigidbody playerRigidbody;

    public LayerMask groundLayerMask;

    private float groundDistance = 1.5f;

    private Animator _animator;

    public GameObject icon;




    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        _animator = icon.GetComponent<Animator>();

        healthBar = FindObjectOfType<Healthbar>();
        MaxHealth = currenthealth;
        healthBar.SetMaxHealth(MaxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        Jumping();

        Diving();

        ActionStomp();

        Stop();

    }
    private void FixedUpdate()
    {

        

        horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");

       playerRigidbody.AddRelativeForce(Vector3.forward * speed * verticalInput, ForceMode.Force);
       playerRigidbody.AddRelativeForce(Vector3.right * horizontalInput * speed);
        //transform.Rotate(Vector3.up * (speed *2) * Time.deltaTime * horizontalInput);

        // Velocidad maxima del rigidbody del player
        if (playerRigidbody.velocity.magnitude > maxspeed)
            {
                // Mantiene a la velocidad maxima
                playerRigidbody.velocity = playerRigidbody.velocity.normalized * maxspeed;
           }

        // if(verticalInput == 0)
        //{
        //  playerRigidbody.velocity = playerRigidbody.velocity.normalized * 0;
        //  }

        Stop();

    }

    private void OnCollisionEnter(Collision othercollider)
    {
        if (othercollider.gameObject.CompareTag("Obstacle"))
        {
            GetHurt();
        }
        
    }
    //Salta
    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
           // verticalVelocity = -gravity * Time.deltaTime;
           // verticalVelocity = jumpForce;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            verticalVelocity -= gravity * Time.deltaTime;

            isJumping = true;

            canDive = true;
        }
       // else
        //{
           // if (!IsOnGround())
           // {
              //  verticalVelocity -= gravity * Time.deltaTime;
           // }
      //  }
       // Vector3 moveVector = Vector3.zero;
       // moveVector.x = Input.GetAxis("Horizontal") * speed;
       // moveVector.y = verticalVelocity;
       // moveVector.z = Input.GetAxis("Vertical") * speed;


        
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
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Aplica una fuerza, un impulso vertical hacia abajo
            playerRigidbody.AddForce(Vector3.down * stompForce, ForceMode.Impulse);

          
        }
    }
    private void Stop()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerRigidbody.AddForce(Vector3.back * speed/2 , ForceMode.Force);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerRigidbody.AddForce(Vector3.right * speed/2, ForceMode.Force);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerRigidbody.AddForce(Vector3.forward * speed / 2, ForceMode.Force);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRigidbody.AddForce(Vector3.left * speed / 2, ForceMode.Force);
        }
    }

    public void GetHurt()
    {
        currenthealth--;

      
        
        if (currenthealth == 2)
        
        {

            speed += 2f;
            maxspeed += 2f;
            jumpForce += 2f;
            healthBar.SetHealth(currenthealth);
            
            
        }

        if (currenthealth == 1)

        {
            speed += 2f;
            maxspeed += 2f;
            jumpForce += 2f;
            healthBar.SetHealth(currenthealth);

            _animator.Play("Idle3");
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
