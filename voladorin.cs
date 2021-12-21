using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class voladorin : MonoBehaviour
{

    private PlayerController thePlayer;
    public float moveSpeed;
    public float playerRange;
    public LayerMask playerLayer;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);
        
         if (playerInRange)
            {
                
                
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
              
                return;
            }
    }


    void onDrawGizmosSelected()
    {
         Gizmos.DrawSphere(transform.position, playerRange);
    }
}
