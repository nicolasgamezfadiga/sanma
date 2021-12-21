    using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {


public GameObject enemyStar;
    public float playerRange;
    public Transform launchPoint;
    public float waitBetweenShots;
    public float shotCounter;
    public float moveSpeedCaminando;

	public float moveSpeed;
	public bool moveRight;
   private Animator anim;
    public Transform wallCheck;
	public float wallCheckRadius;

    public float SanmaCheckRadius;
	public LayerMask whatIsWall;

    public LayerMask whatIsSanma;
	private bool hittingWall;
   // public ShotAtPlayerInRange mover;
	private bool notAtEdge;

    private bool girar;

    public Transform sanMaCheck;
	public Transform edgeCheck;

    public ShotAtPlayerInRange moverseOk;
    
    public PlayerController sanMa;

	// Use this for initialization
	void Start () {
      //  mover = FindObjectOfType<ShotAtPlayerInRange>();
        anim = GetComponent<Animator>();
        moverseOk = FindObjectOfType<ShotAtPlayerInRange>();

        sanMa = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {

		hittingWall = Physics2D.OverlapCircle (wallCheck.position, wallCheckRadius, whatIsWall);

		notAtEdge = Physics2D.OverlapCircle (edgeCheck.position, wallCheckRadius, whatIsWall);

        girar = Physics2D.OverlapCircle (sanMaCheck.position, SanmaCheckRadius, whatIsSanma);


    
         
        if (hittingWall || !notAtEdge || girar)
			moveRight = !moveRight;


         
            if (moveRight)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }


            Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;




        if(transform.localScale.x < 0 && sanMa.transform.position.x > transform.position.x && sanMa.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
             
           // girar = false;
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           moveSpeed = 0;
            anim.SetBool("disparo", true);
           
           
        }
        
        if (transform.localScale.x > 0 && sanMa.transform.position.x < transform.position.x && sanMa.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
              
           // girar = true;
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           moveSpeed = 0;
          anim.SetBool("disparo", true);
            
        } 

         if (sanMa.transform.position.x < transform.position.x - playerRange)
        {
            moveSpeed = moveSpeedCaminando;
            anim.SetBool("disparo", false);
        }

         if (sanMa.transform.position.x > transform.position.x + playerRange)
        {
            moveSpeed = moveSpeedCaminando;
            anim.SetBool("disparo", false);
        }

       }
     

     

}
