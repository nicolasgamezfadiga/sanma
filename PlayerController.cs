using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<PlayerController>();
            }
            return instance;
        }
    }
    
  //  public bool jump;
   // public bool jumpAttack;
   public bool golpazo;
    public float jumpForce;
    public float movementSpeed;
    private float moveVelocity;
  //  public float jumpHeight;

    //public Transform groundCheck;
    //public float groundCheckRadius;
    public float groundRadius;
    public LayerMask whatIsGround;
  //  private bool isGrounded;
    private bool doubleJumped;
    public bool dashDer;
    public float moveSpeedDash;
    private Animator anim;
    //private bool attack;
    //public GameObject espaditaEstela;
    public Transform firePoint;
    public Transform firePoint2;

    public float mantenerCarga;
    public GameObject carguita;
    public GameObject ninjaStar;
    public GameObject ninjaStar2;
    // public GameObject mira;
    // public float velocidad;
    // private float velocidadMira;

    public float shotDelay;
    private float shotDelayCounter;

    public float knockback;
    public float kncockbackLenght;
    public float knockbackCount;
    public bool knockFromRight;
    public bool airControl;
    public bool timeSlow;
    public float timeSlowTimer;
    public float cargarTiempo;
    public float restarSuperDisparo;
    public Rigidbody2D MyRigibody { get; set; }
    public bool Attack { get; set; }
    public bool Jump { get; set; }
    public bool OnGround { get; set; }


    

    public float maxTiempo;
    public GameObject firePointt;
    public LayerMask layer;
    //public NinjaStarController ninjaStarController;

    public bool doubleJumpActivated = false;
    public Transform[] groundPoints;
    




    // Use this for initialization
    void Start()
    {
        // ninjaStarController = FindObjectOfType<NinjaStarController>();
        anim = GetComponent<Animator>();
        MyRigibody = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate()
    {
        OnGround = IsGrounded();
        float horizontal = Input.GetAxis("Horizontal");
        handleMovement(horizontal);
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
       // handleAttack();
        //resetValues();
        
        handleLayer();
       
        
        

    }
    // Update is called once per frame
    void Update()
    {
        
         handleInput();
        
        
        
       /* if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);


        if (Input.GetButtonDown("Jump") && grounded)
        {

            //GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded && doubleJumpActivated)
        {

            //GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
            doubleJumped = true;
        }*/

        //moveVelocity = 0f;


        // velocidadMira = velocidad * Input.GetAxisRaw("TiroLento");
        // mira.GetComponent<Rigidbody2D>().velocity = new Vector2(mira.GetComponent<Rigidbody2D>().velocity.x, velocidadMira);

        /*  if (Input.GetAxisRaw("Horizontal") != 0 && timeSlow == false)
           {
               cargarTiempo ++;
               if(cargarTiempo > maxTiempo)
               {
                   cargarTiempo = maxTiempo;
               }



           }*/


       if (knockbackCount <= 0)
         {
           if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
            moveVelocity = movementSpeed * Input.GetAxisRaw("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
                anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
            }


         }
        else {
         if (knockFromRight)
       
          
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, knockback);
          // anim.SetTrigger("golpe");
          
         if (!knockFromRight)
         
         
          GetComponent<Rigidbody2D>().velocity = new Vector2(0, knockback);
        // anim.SetTrigger("golpe");
         knockbackCount -= Time.deltaTime;
        }




        if (GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            // ninjaStar2.transform.localScale = new Vector3(3f, 3f, 1f);
            // ninjaStar.transform.localScale = new Vector3(1f, 1f, 1f);
            dashDer = true;
        }

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);


            dashDer = false;
        }

        if (cargarTiempo < 1)
        {
            timeSlow = false;

        }
        if (timeSlow)
        {
            firePointt.SetActive(true);
            Time.timeScale = 0.1f;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            cargarTiempo--;




        }
        else
        {
            //firePointt.SetActive(false);
            Time.timeScale = 1f;

        }

        /* if (Input.GetButtonDown("Dash") && dashDer == true)
         {
             GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeedDash, GetComponent<Rigidbody2D>().velocity.y);
         }*/

        /* if (Input.GetButtonDown("Dash") && dashDer == false)
         {
             GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeedDash, GetComponent<Rigidbody2D>().velocity.y);
         }*/

        /* if (Input.GetButtonDown("TimeSlow"))
         {
             timeSlow = !timeSlow;
         }*/

        /* if (anim.GetBool("Disparo"))
             anim.SetBool("Disparo", false);*/

        /* if (Input.GetButtonDown("Fire1") && timeSlow == true)
         {

             cargarTiempo -= restarSuperDisparo;
             mantenerCarga = Time.deltaTime;
             anim.SetBool("Disparo", true);
             Instantiate(ninjaStar2, firePoint2.position, firePoint2.rotation);
             RaycastHit2D hit = Physics2D.Raycast(firePoint2.position, ninjaStarController.destino.position, 100, layer);
         }*/

        /*if (Input.GetButtonDown("Fire1") && timeSlow == false) 
        {

            mantenerCarga = Time.deltaTime;
            anim.SetBool("Disparo", true);
            Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
           // RaycastHit2D hit = Physics2D.Raycast(firePoint2.position, ninjaStarController.destino.position, 100, layer);
        }*/

        /*  if (Input.GetButton ("Fire1") )
              {
              // carguita.SetActive(true);
              //   mantenerCarga = Time.deltaTime;

              mantenerCarga += Time.deltaTime;
              if (mantenerCarga > 0.5f)
              {
                  carguita.SetActive(true);
              }*/
        //Instantiate(carguita, transform.position, transform.rotation);
        // shotDelayCounter -= Time.deltaTime;

        //if(shotDelayCounter <=0)
        //{
        //shotDelayCounter = shotDelay;
        //Instantiate(ninjaStar2, firePoint.position, firePoint.rotation);
        // }
        //  if (anim.GetBool("Sword"))
        // anim.SetBool("Sword", false);



        /*  if (Input.GetButtonDown("Fire1"))
          {
              attack = true;


              //espaditaEstela.SetActive(true);
              //   anim.SetBool("Sword", true);

              // moveSpeed = 0;

          }/*

          /* if (Input.GetButtonUp("Fire1"))
           {
               //espaditaEstela.SetActive(false);
               anim.SetBool("Sword", false);
               moveSpeed = 10;

           }*/


        /* if (Input.GetKeyDown(KeyCode.L))
         {
             anim.SetBool("Sword", false);
         }*/


    }

    /*  if (Input.GetButtonUp("Fire1") && mantenerCarga > 0.5f )
      {
          mantenerCarga = 0;
          carguita.SetActive(false);
          Instantiate(ninjaStar2, firePoint.position , firePoint.rotation);
      }*/

    // if (anim.GetBool("Disparo") && GetComponent<Rigidbody2D>().velocity.x > 0.1f)
    //     {

    //  }


    //}
  /*  void OnCollisionEnter2D(Collision2D collision) 
        
    {
        //if (collision.gameObject.name == "plane") {
        //	doubleJumped = true;
        //}
        voladorin volado = collision.collider.GetComponent<voladorin>();
        if(enemy != null)
        {
            triggerHurt();
        }
        Debug.Log(collision.gameObject.name);
    }

    public void triggerHurt(float hurtTime)
    {
       StartCoroutine (HurtBlinker(hurtTime));
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);

        yield return new WaitForSeconds(hurtTime);

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }*/
 /*  public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

    }*/
    private void handleMovement(float horizontal)
    {
        
        if(MyRigibody.velocity.y < 0)
        {
            anim.SetBool("land", true);
        }
        if (!Attack && (OnGround || airControl))
        {
            MyRigibody.velocity = new Vector2(horizontal * movementSpeed, anim.velocity.y);
        }
        if (Jump && MyRigibody.velocity.y == 0)
        {
            
            MyRigibody.AddForce(new Vector2(0, jumpForce));
        }
        anim.SetFloat("Speed", Mathf.Abs(horizontal));
        /*if(myRigidBody.velocity.y < 0)
        {
            anim.SetBool("Land", true);
        }
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            //  moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
            myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
            
        }
        if (isGrounded && jump)
        {
            anim.SetTrigger("jump");
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));
            
            
        }

       anim.SetFloat("Speed", Mathf.Abs(horizontal));*/
    }
   /* private void handleAttack()
    {
        if (attack && isGrounded && !this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))

        {
            myRigidBody.velocity = Vector2.zero;
            anim.SetTrigger("Attack");
            
            
            // myAnimator.SetTrigger("Attack");
        }
        if(jumpAttack && !isGrounded && !this.anim.GetCurrentAnimatorStateInfo(1).IsName("jumpAttack"))
        {
            anim.SetBool("jumpAttack", true);
        }

        if(!jumpAttack && !this.anim.GetCurrentAnimatorStateInfo(1).IsName("jumpAttack"))
        {
            anim.SetBool("jumpAttack", false);
        }



    }*/
    private void handleInput()
    {
        if (Input.GetButtonDown("Jump") /*&& golpazo == true*/)
        {
            
            anim.SetTrigger("jump");
            //golpazo = false;
           // jump = true;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("attack");
          //  attack = true;
            //jumpAttack = true;
        }
    }

  /*  private void resetValues()
    {
        jump = false;
        attack = false;
        jumpAttack = false;
    }*/

    public bool IsGrounded()
    {
        if(MyRigibody.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        
                       // anim.ResetTrigger("jump");
                       // anim.SetBool("Land", false);
                        return true;
                        
                        
                    }
                }
            }

        }

        return false;
    }

    public void handleLayer()
    {
        if(!OnGround)
        {
            anim.SetLayerWeight(1, 1);
        }
        else /*if(golpazo == false)*/
        {
            anim.SetLayerWeight(1, 0);
        }
    }

}
