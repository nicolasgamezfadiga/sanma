using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour {

	//public float speed;

	public PlayerController player; 

	public GameObject enemyDeathEffect;

	public GameObject impactEffect;

	//public int pointsForKill;

	//public float rotationSeed;

	public int damageToGive;

  //  public Transform destino;
   // public LayerMask layer;

    // Use this for initialization
    void Start () {
     
		player = FindObjectOfType<PlayerController> ();



		/*if (player.transform.localScale.x < 0)
			speed = -speed;
			rotationSeed = -rotationSeed;*/
	}
	
	// Update is called once per frame
	void Update () {



        // GetComponent<Rigidbody2D>().velocity = new Vector2(destino.position.x, destino.position.y);
        // RaycastHit2D hit = Physics2D.Raycast(player.firePoint2.position, destino.position, 100, layer);
        
       // GetComponent<Rigidbody2D>().transform.Translate (Vector3.right * Time.deltaTime * speed);
      //  GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        //GetComponent<Rigidbody2D> ().angularVelocity = rotationSeed;
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//Destroy (other.gameObject);
			//ScoreManager.AddPoints(pointsForKill);

			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
            Instantiate(impactEffect, transform.position, transform.rotation);
        }

		    
			//Destroy (gameObject);
	}

}
