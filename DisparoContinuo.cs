using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoContinuo : MonoBehaviour
{
    
    public GameObject enemyStar;

    public Transform launchPoint;

    public float waitBetweenShots;
    private float shotCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        shotCounter = waitBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
         if(shotCounter < 0)
        {
           // girar = false;
            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
           
        }
    }
}
