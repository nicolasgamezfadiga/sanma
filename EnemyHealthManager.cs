using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyHealth;

	public GameObject deathEffect;

	//public int pointsOnDeath;

    //public EnemyManager enemyManager;

	// Use this for initialization
	void Start () {

       // enemyManager = FindObjectOfType<EnemyManager>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (enemyHealth <= 0) {

			Instantiate(deathEffect, transform.position, transform.rotation);
			//ScoreManager.AddPoints(pointsOnDeath);
         //   enemyManager.muertos += 1;
			Destroy(gameObject);
                   
		}

	
	}

	public void giveDamage(int damageToGive)
	{
		enemyHealth -= damageToGive;

	}


}
