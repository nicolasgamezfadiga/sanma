using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminarYDisparar : MonoBehaviour {

    public bool tirito = false;
    public float tiempoCaminando;
    public float moveSpeed;
    private Animator anim;
    public Transform launchPoint;
    public float waitBetweenShots;
    public float shotCounter;
    public GameObject enemyStar;
    public float speed;

    // Use this for initialization
    void Start () {
        shotCounter = waitBetweenShots;

        anim = GetComponent<Animator>();

    }

  
    // Update is called once per frame
    void Update () {

        tiempoCaminando += Time.deltaTime;
        shotCounter -= Time.deltaTime;

        if (tiempoCaminando < 1f)
        {
            moveSpeed = speed;
            //transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }


        if (tiempoCaminando > 1.1f && shotCounter < 0)
        {
            moveSpeed = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            tirito = true;
            anim.SetBool("DisparoReptil", true);
            //quieto.moveSpeed = 0;



            Instantiate(enemyStar, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;

        }
    }
}
