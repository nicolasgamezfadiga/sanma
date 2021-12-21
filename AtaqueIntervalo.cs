using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueIntervalo : MonoBehaviour
{
   
    // Start is called before the first frame update
    public float waitBetweenShots;
    public float shotCounter;
    
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
       //  shotCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter += Time.deltaTime;

         if(shotCounter > 10)
        {
          
           anim.SetBool("fuego", true);
           anim.SetBool("disparin", false);
           
           
        }
         if (shotCounter > 11)
        {
            
          shotCounter = 0;
          anim.SetBool("disparin", true);
           anim.SetBool("fuego", false);
            
        }
    }
}  
