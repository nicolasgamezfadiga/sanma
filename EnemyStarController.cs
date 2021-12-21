using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStarController : MonoBehaviour {

    public float speed;

    public float invincibleTimeAfterHurt;
    public float levantadita;

    public PlayerController player;

    public CaminarYDisparar reptil;

   // public GameObject enemyDeathEffect;

    public GameObject impactEffect;

   // public int pointsForKill;

    public float rotationSeed;

    public int damageToGive;

    //public Transform destino;
    // public LayerMask layer;

    // Use this for initialization
    void Start()
    {

        player = FindObjectOfType<PlayerController>();
        reptil = FindObjectOfType<CaminarYDisparar>();


      // if (player.transform.position.x < reptil.transform.position.x)
         //   speed = -speed;

     //   if (player.transform.position.x > reptil.transform.position.x && speed < 0)
          //  speed = speed * -1;
        //rotationSeed = -rotationSeed;
    }

    // Update is called once per frame
    void Update()
    {




        // GetComponent<Rigidbody2D>().velocity = new Vector2(destino.position.x, destino.position.y);
        // RaycastHit2D hit = Physics2D.Raycast(player.firePoint2.position, destino.position, 100, layer);
        //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, levantadita);
        GetComponent<Rigidbody2D>().transform.Translate(Vector3.right * Time.deltaTime * speed);
        GetComponent<Rigidbody2D>().transform.Translate(Vector3.up * Time.deltaTime * levantadita);
        //  GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        //GetComponent<Rigidbody2D> ().angularVelocity = rotationSeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            triggerHurt(invincibleTimeAfterHurt);
            //Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            //Destroy (other.gameObject);
            //ScoreManager.AddPoints(pointsForKill);

            HealthManager.HurtPlayer(damageToGive);

            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.kncockbackLenght;

            if (other.transform.position.x < transform.position.x)
                player.knockFromRight = true;
            else
                player.knockFromRight = false;
        }

        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
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
    }
}


