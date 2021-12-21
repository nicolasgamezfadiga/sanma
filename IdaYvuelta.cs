using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdaYvuelta : MonoBehaviour {

    public PlayerController player;
    public Transform pisito;

    public float speed;
	// Use this for initialization
	void Start () {

        player = FindObjectOfType<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {


        GetComponent<Rigidbody2D>().transform.Translate(Vector3.right * Time.deltaTime * speed);


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "pared2")
        {

            speed = speed * -1;
            //Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            //Destroy (other.gameObject);
            //ScoreManager.AddPoints(pointsForKill);

            // HealthManager.HurtPlayer(damageToGive);
        }

        if (other.tag == "pared1")
        {

            speed = speed * -1;
            //Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
            //Destroy (other.gameObject);
            //ScoreManager.AddPoints(pointsForKill);

            // HealthManager.HurtPlayer(damageToGive);
        }
        

        //Instantiate(impactEffect, transform.position, transform.rotation);
        //Destroy(gameObject);
    }

}
