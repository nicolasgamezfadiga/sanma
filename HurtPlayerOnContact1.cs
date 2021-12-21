using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HurtPlayerOnContact1 : MonoBehaviour {


    private bool flashactive;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer playerSprite;
    public float tiempoAnimacion;

    public float quietito;

    public float movidito;
    public float tiempoAnimacionMax;
    public float invincibleTimeAfterHurt;
    private Animator anim;
   // private float gravityStore;
   // public float parpadeito;
//	public int damageToGive;
    public PlayerController player;
  //  public GameObject impactEffect;
  //  private Animator anim;
    public float tiempo;
    // Use this for initialization
    void Start () {
     
       // anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();
        anim = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
      
      if (flashactive)  
      {
          if (flashCounter > 4f)
          {
              Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
             // player.transform.localScale = new Vector3(1f, 0f, 1f);
              
          } else if (flashCounter > 3.5f)
          {
                 Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = true;
              //player.transform.localScale = new Vector3(1f, 1f, 1f);
          } else if (flashCounter > 3f)
          {
                 Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
              //player.transform.localScale = new Vector3(1f, 1f, 1f);
          } else if (flashCounter > 2.5f)
          {
                 Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = true;
              //player.transform.localScale = new Vector3(1f, 1f, 1f);
          } else if (flashCounter > 2f)
          {
              Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
             // player.transform.localScale = new Vector3(1f, 0f, 1f);
              
          } else if (flashCounter > 1.5f)
          {
                 Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = true;
              //player.transform.localScale = new Vector3(1f, 1f, 1f);
          } else if (flashCounter > 1f)
          {
                 Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
              //player.transform.localScale = new Vector3(1f, 1f, 1f);
          } else if (flashCounter > 0.5f)
          {
                 Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = true;
              //player.transform.localScale = new Vector3(1f, 1f, 1f);
          } 




            else if (flashCounter > 0f)
          {
                 Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
               // player.transform.localScale = new Vector3(1f, 0f, 1f);
          }    
          else
          {
              Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = true;
            // player.transform.localScale = new Vector3(1f, 1f, 1f);
              flashactive = false;
          }

          flashCounter -= Time.deltaTime;
      }
	//anim.SetBool("golpazo", false);
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
         //Debug.Log("hola");
        if (other.tag == "Golpe")
        {
            flashCounter = invincibleTimeAfterHurt;
            player.movementSpeed = quietito;
          
            Debug.Log("hola");
           triggerHurt(invincibleTimeAfterHurt);
           triggerGolpazo(tiempoAnimacionMax);
          /*    StartCoroutine ("parpadeoCo");
            Instantiate(impactEffect, transform.position, transform.rotation);*/
           
            
           /* HealthManager.HurtPlayer(damageToGive);
          
            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.kncockbackLenght;

            if (other.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;*/

            //parpadeo();
            /*if (other.name == "Player")
            {
                HealthManager.HurtPlayer(damageToGive);

                var player = other.GetComponent<PlayerController>();
                player.knockbackCount = player.kncockbackLenght;

                if (other.transform.position.x < transform.position.x)
                    player.knockFromRight = true;
                else
                    player.knockFromRight = false;
                Instantiate(impactEffect, transform.position, transform.rotation);*/

        }
	}

   /* void parpadeo(){
            
            StartCoroutine ("parpadeoCo");
          
      parpadeito = -Time.deltaTime;


        while (parpadeito < 4)
        {
        if (parpadeito < 1 )
        {
            player.enabled = false;
        }
         if (parpadeito < 2 && parpadeito > 1 )
        {
            player.enabled = true;
        }
         if (parpadeito < 3 && parpadeito > 2 )
        {
            player.enabled = false;
        }  

    }*/

 public void triggerGolpazo(float culete)
    {   
         

       StartCoroutine (golpazo(culete));
    }

     IEnumerator golpazo(float culete)
    {
       
      anim.SetBool("golpazo", true);
        yield return new WaitForSeconds(culete);
        player.movementSpeed = movidito;
        anim.SetBool("golpazo", false);
        flashactive = true;

    }

   public void triggerHurt(float hurtTime)
    {   
        
        //anim.SetBool("golpazo", false);
        // player.golpazo = false;
        Debug.Log("hola");
       StartCoroutine (HurtBlinker(hurtTime));
       
    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");

      /* Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;*/

        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);
         
        
        yield return new WaitForSeconds(hurtTime);

       /*  Renderer[] rs2 = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs2)
            r.enabled = true;*/
       
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
    }
    
   /* public IEnumerator parpadeoCo()
    {
        
        player.enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
		gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;

        yield return new WaitForSeconds (tiempo);

        player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
        player.enabled = true;
        Renderer[] rs2 = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs2)
            r.enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;

    }*/
}
