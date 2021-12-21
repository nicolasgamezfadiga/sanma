using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAtPlayerInRange : MonoBehaviour {

    public float playerRange;
    public float moveSpeedy;
    public GameObject enemyStar;

    public PlayerController player;

    public Transform launchPoint;

    public float waitBetweenShots;
    private float shotCounter;
    public EnemyPatrol moverse;
	public Animator aanim;
   public bool frenarse;

   

	void Start () {
        aanim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
       
        moverse = FindObjectOfType<EnemyPatrol>();

        shotCounter = waitBetweenShots;
        
	}

    void fixUpdate(){
     
    }
	
	// Update is called once per frame
	void Update () {
        

        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;




        if(transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0)
        {
             
           // girar = false;
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           moverse.moveSpeed = 0;
            aanim.SetBool("disparo", true);
           
           
        }
        
        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
              
           // girar = true;
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           moverse.moveSpeed = 0;
          aanim.SetBool("disparo", true);
            
        } 

         if (player.transform.position.x < transform.position.x - playerRange)
        {
            moverse.moveSpeed = moverse.moveSpeedCaminando;
            aanim.SetBool("disparo", false);
        }

         if (player.transform.position.x > transform.position.x + playerRange)
        {
            moverse.moveSpeed = moverse.moveSpeedCaminando;
            aanim.SetBool("disparo", false);
        }

        
    }
       /* if (player.transform.position.x < transform.position.x + playerRange)
        {
            frenarse ();
           
        }else{
            caminar();
        }

        if (player.transform.position.x + playerRange > transform.position.x )
        {
            frenarse ();
           
        }else{
            caminar();
        }*/

         /*if(player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange)
        {
            frenarse ();
           
        }else{
            caminar();
        }*/
        
    


   

        
   
   /* void frenarse (){


        moverse.moveSpeed = 0;

    }

    void caminar (){

        
        moverse.moveSpeed = 3;
        

    }*/
    
 /*   public bool tirito = false; 
    public float playerRange;
    public float moveSpeedy;
    public GameObject enemyStar;
    private Animator anim;
    public PlayerController player;
    public EnemyPatrol quieto;
    public Transform launchPoint;
    public bool moverse;
    public float waitBetweenShots;
    private float shotCounter;
	
	void Start () {
        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        shotCounter = waitBetweenShots;
        quieto = FindObjectOfType<EnemyPatrol>();
	}

    // Update is called once per frame
    void Update() {
        Debug.DrawLine(new Vector3(transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));
        shotCounter -= Time.deltaTime;
      //  anim.SetFloat("MovimientoReptil", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x - playerRange && shotCounter < 0)
        {
            tirito = true;
            anim.SetBool("DisparoReptil", true);
            //quieto.moveSpeed = 0;

           

            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;

            

        }


        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0)
        {
            tirito = true;
            anim.SetBool("DisparoReptil", true);
            // quieto.moveSpeed = 0;
            


            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;

        }

        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x > transform.position.x + playerRange && shotCounter < 0)
        {
            
            tirito = false;
            anim.SetBool("DisparoReptil", false);
        }

        


        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x < transform.position.x - playerRange && shotCounter < 0)
        {
            
            tirito = false;
            anim.SetBool("DisparoReptil", false);
        }


        }*/
}
