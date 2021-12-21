    using UnityEngine;
using System.Collections;

public class EnemyPatrolSoldadito : MonoBehaviour {

public HealthManager healthManager1;
public GameObject enemyStar1;
    public float playerRange1;
    public Transform launchPoint;
    public float waitBetweenShots;
    private float shotCounter;
    public float moveSpeedCaminando;

	private float moveSpeed;
	private bool moveRight;
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
    
    public PlayerController sanMa1;

	// Use this for initialization
	void Start () {
      //  mover = FindObjectOfType<ShotAtPlayerInRange>();
        anim = GetComponent<Animator>();
        moverseOk = FindObjectOfType<ShotAtPlayerInRange>();

        sanMa1 = FindObjectOfType<PlayerController>();
        healthManager1 = FindObjectOfType<HealthManager>();
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
                transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }


            Debug.DrawLine(new Vector3(transform.position.x - playerRange1, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange1, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;




        if(transform.localScale.x < 0 && sanMa1.transform.position.x > transform.position.x && sanMa1.transform.position.x < transform.position.x + playerRange1 && shotCounter < 0)
        {
            
          // girar = false;
            Instantiate(enemyStar1, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           moveSpeed = 0;
            anim.SetBool("disparo1", true);
           
           
        }
        
        if (transform.localScale.x > 0 && sanMa1.transform.position.x < transform.position.x && sanMa1.transform.position.x > transform.position.x - playerRange1 && shotCounter < 0)
        {
           
          //girar = true;
            Instantiate(enemyStar1, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           moveSpeed = 0;
          anim.SetBool("disparo1", true);
            
        } 

         if (sanMa1.transform.position.x < transform.position.x - playerRange1)
        {
            moveSpeed = moveSpeedCaminando;
            anim.SetBool("disparo1", false);
        }

         if (sanMa1.transform.position.x > transform.position.x + playerRange1)
        {
            moveSpeed = moveSpeedCaminando;
            anim.SetBool("disparo1", false);
        }

       }
     

     

}
