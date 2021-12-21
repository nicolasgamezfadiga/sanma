using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoMalote : MonoBehaviour
{
    public GameObject enemyStar;
    
    public Transform launchPoint;
    public float waitBetweenShots;
    public float shotCounter;
    public float shotCounter1;
    public float esperar;
    public bool ataqueOk;
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = waitBetweenShots;
       
    }
    void fixUpdate(){
    
    }

    // Update is called once per frame
    void Update()
    {
        esperar += Time.deltaTime;
        shotCounter -= Time.deltaTime;
        shotCounter1 += Time.deltaTime;

        if (esperar < 1)
        {
             ataqueOk = true;
        } 


    
         if (esperar > 1)
        {
          
          ataqueOk = false;  
       
        }


        if(esperar > 3)
        {
            esperar = 0;
        }

         if(shotCounter < 0 && ataqueOk == true)
        {
           // girar = false;
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           
        } 

        

    }


    
}
