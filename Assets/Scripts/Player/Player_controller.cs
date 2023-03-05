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

    private float gravity = 2f;
    
    public float diveForce = 12f;

    public float stompForce = 15f;


    [Header("controller")]

    private float horizontalInput, verticalInput;

    private bool isJumping;

    public float jumpCutMultiplier = 9.8f;

    private int lastJumpTime;

    private bool jumpInputReleased;

    private bool canDive;

    private bool canDJump;

    public float turnSmoothTime = 0.1f;

    float turnSmoothVelocity;

    

    [Header("elements")]

    private Rigidbody playerRigidbody;

    public LayerMask groundLayerMask;

    private float groundDistance = 0.5f;

    private Animator _animator;

    private Animator Laskaanim;

    public GameObject icon;

    private GameObject focalPoint;

    private TrailRenderer trail;

    public GameObject collectible;

    public int Rcollected;

    private GameManager gameManager;

    public ParticleSystem runDust;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        _animator = icon.GetComponent<Animator>();

        Laskaanim = GetComponent<Animator>();

        healthBar = FindObjectOfType<Healthbar>();

        MaxHealth = currenthealth;

        healthBar.SetMaxHealth(MaxHealth);

        focalPoint = GameObject.Find("FocalPoint");

        trail = GetComponent<TrailRenderer>();

        trail.enabled = false;

        Rcollected = 0;

        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Jumping();

        Diving();

        ActionStomp();

        DoubleJump();

        GoSlow();

        fall();

        Stop();


     

        //transform.rotation = focalPoint.transform.rotation;
        // Rota en direccion al FocalPoint(Camara) en Y
        //transform.LookAt(focalPoint.transform);
        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);

    }
    private void FixedUpdate()
    {

        

        horizontalInput = Input.GetAxis("Horizontal");
       verticalInput = Input.GetAxis("Vertical");

       //playerRigidbody.AddRelativeForce(Vector3.forward * speed * verticalInput, ForceMode.Force);
       //playerRigidbody.AddRelativeForce(Vector3.right * horizontalInput * speed);

        playerRigidbody.AddForce(focalPoint.transform.forward * verticalInput * speed  , ForceMode.Force);
        playerRigidbody.AddForce(focalPoint.transform.right * horizontalInput * speed);

        if (Mathf.Abs(verticalInput) != 0 || Mathf.Abs(horizontalInput) != 0)
        {
            Laskaanim.SetBool("IsRunning", true);

            if (Laskaanim.GetBool("IsAngry"))
            {
                Laskaanim.SetBool("IsRunning", true);

            }
        }
        else
        {
            Laskaanim.SetBool("IsRunning", false);
            if (Laskaanim.GetBool("IsAngry"))
            {
                Laskaanim.SetBool("IsRunning", false);
               
            }
        }
        
        //transform.Rotate(Vector3.up * (speed *2) * Time.deltaTime * horizontalInput);

        if(speed>= 40)
        {
            runDust.gameObject.SetActive(true);
            runDust.Play();
        }
        else
        {
            runDust.gameObject.SetActive(false);
            runDust.Stop();
        }

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

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.CompareTag("Heal"))
        {
            Getheal();
        }
        
    }

    //Salta
    public void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround())
        {
            
            verticalVelocity = jumpForce;

            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            verticalVelocity -= gravity * Time.deltaTime;

            isJumping = true;

            canDive = true;

            canDJump = true;

            Laskaanim.SetBool("IsJumping", true);
        } 
       


        
    }
    public void fall()
    {
        if (!IsOnGround())
        {
            playerRigidbody.AddForce(Vector3.down * gravity, ForceMode.Force);

        }
    }

    public void OnJumpUp()
    {
        if (playerRigidbody.velocity.y > 0 && isJumping)
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
            
            playerRigidbody.AddForce(Vector3.up * 15, ForceMode.Impulse);

            playerRigidbody.AddForce(focalPoint.transform.forward * diveForce, ForceMode.VelocityChange);

            canDive = false;
            Laskaanim.SetBool("IsDiving", true);
        }

        

    }
    public void ActionAttack()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Laskaanim.SetBool("IsAttacking", true);
            Laskaanim.Play("attack");
        }
        else
        {
            Laskaanim.SetBool("IsAttacking", false);

        }


    }
    private void DoubleJump()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !IsOnGround() && canDJump)
        {
            playerRigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);

            canDJump = false;

            
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

            speed += 5f;

            maxspeed += 5f;

            jumpForce += 2f;

            healthBar.SetHealth(currenthealth);


            _animator.Play("Idle2");


        }

        if (currenthealth == 1)

        {
            speed += 5f;

            maxspeed += 5f;

            jumpForce += 2f;

            healthBar.SetHealth(currenthealth);

            _animator.Play("Idle3");
            trailfx();

            Laskaanim.SetBool("IsAngry", true);
        }


    }

    public void GoSlow()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && IsOnGround())
        {
            speed -= 15;
            Laskaanim.SetBool("IsWalking", true);
            Laskaanim.SetBool("IsRunning", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) && IsOnGround())
        {
            speed +=15;
            Laskaanim.SetBool("IsWalking", false);
            Laskaanim.SetBool("IsRunning", true);

        }
    }
    
    private void trailfx()
    {
        if(speed >= 39)
        {
            trail.enabled = true;
        }
    }

    public void Getheal()
    {
        currenthealth++;
    }

    public bool IsOnGround()
    {
        // Raycast hacia abajo con una distancia determinada
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hitData, groundDistance, groundLayerMask);


        Laskaanim.SetBool("IsAttacking", false);
        if(hitData.collider == null)
        {
            Laskaanim.SetBool("IsJumping", false);
            Laskaanim.SetBool("IsDiving", false);

        }

        // Devuelve cualquier bool diferente a NULL
        return hitData.collider != null;

        
    }
  
 }