using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionArma : MonoBehaviour
{
    public Transform target;
    public float speed;

    public DisparoMalote manitos;
    // Start is called before the first frame update
    void Start()
    {
      manitos = FindObjectOfType<DisparoMalote>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direction = transform.position - target.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
         Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        
      
    /*   if(manitos.shotCounter1 < 10)
        {
          noErrar();
        }

        if(manitos.shotCounter1 > 10)
        {
          errar();
        }

        if(manitos.shotCounter1 > 14)
        {
            manitos.shotCounter1 = 0;
            errar();
        }
      */  
        
         
        
    }

   /* void errar (){

        Vector2 direction = transform.position * 4 - target.position * 5;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
         Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    void noErrar(){

        Vector2 direction = transform.position - target.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
         Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }*/
}

