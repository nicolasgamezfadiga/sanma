using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerEnemyMove : MonoBehaviour {

    public GameObject enemyStar;
    public Transform launchPoint;

    public float waitBetweenShots;
    public float shotCounterr;
    private PlayerController thePlayer;
    public bool moveRight;
    public float moveSpeed;

    public float playerRange;

    public LayerMask playerLayer;
    public LayerMask whatIsSanma;
    public bool playerInRange;
    public float SanmaCheckRadius;
    public bool facingAway;
    private bool girar;
    public bool followOnLookAway;
    public PlayerController sanMa;
    public Transform sanMaCheck;
	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<PlayerController>();
		sanMa = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
       disparar();
        girar = Physics2D.OverlapCircle (sanMaCheck.position, SanmaCheckRadius, whatIsSanma);


    
         
        if (girar)
			moveRight = !moveRight;


         
            if (moveRight)
            {
                transform.localScale = new Vector3(-1f, 1f, 1);
               // GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
        
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
         shotCounterr -= Time.deltaTime;
        if (!followOnLookAway)
        {
            if (playerInRange)
            {
                
                
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
              
                return;
            }

        }

       /* if ((thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x < 0) || (thePlayer.transform.position.x > transform.position.x && thePlayer.transform.localScale.x > 0))
        {
            facingAway = true;
        }
        else{

            facingAway = false;
        }*/

        if (playerInRange/*&& facingAway*/)
        {
            
            
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
           
        }


    }

    void onDrawGizmosSelected()
    {
        
        Gizmos.DrawSphere(transform.position, playerRange);
    }

    void disparar()
    {
         if (playerInRange && shotCounterr < 0/*&& facingAway*/)
        {
            
            
           
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounterr = waitBetweenShots;
        }
    }
}
