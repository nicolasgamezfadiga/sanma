using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class golpearPersonaje : MonoBehaviour
{
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

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.name == "MaloVolador")
        {
            
              StartCoroutine ("parpadeoCo");
            Instantiate(impactEffect, transform.position, transform.rotation);
           
            
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

   



    

    public IEnumerator parpadeoCo()
    {
     /* player.enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds (tiempo);
        player.enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;*/

          player.GetComponent<BoxCollider2D>().enabled = false;
        Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
        yield return new WaitForSeconds (tiempo);
        //player.enabled = true;
        Renderer[] rs2 = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs2)
            r.enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
    }
}
