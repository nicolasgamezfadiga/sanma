using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

   // public float invincibleTimeAfterHurt;

    private float gravityStore;
    public float parpadeito;
	public int damageToGive;
    public PlayerController player;
    public GameObject impactEffect;
    private Animator anim;
    public float tiempo;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
         
        if (other.name == "Player")
        {
          // triggerHurt(invincibleTimeAfterHurt);
          /*    StartCoroutine ("parpadeoCo");
            Instantiate(impactEffect, transform.position, transform.rotation);*/
           
            
            HealthManager.HurtPlayer(damageToGive);
          
            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.kncockbackLenght;

            if (other.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;

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
  /* public void triggerHurt(float hurtTime)
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
