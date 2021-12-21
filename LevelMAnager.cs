using UnityEngine;
using System.Collections;

public class LevelMAnager : MonoBehaviour {

	public GameObject sanMaMuerto;
	public GameObject currentCheckpoint;

	private PlayerController player;

	public GameObject deathParticle;
	public GameObject respawnParticle;

	//public int pointPenaltyOnDeath;

	public float respawnDelay;

	private CameraController camera;

	private float gravityStore;

    public bool timeSlow; 

	public HealthManager healthManager;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController>();

		camera = FindObjectOfType<CameraController>();
	
		healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {

       
       
    }

	public void RespawnPlayer()
	{
		StartCoroutine ("RespawnPlayerCo");
	}

	public IEnumerator RespawnPlayerCo()
	{
		player.transform.position = sanMaMuerto.transform.position;
        player.enabled = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
		player.GetComponent<CircleCollider2D>().enabled = false;

		Collider2D[] cs = player.GetComponentsInChildren<Collider2D>();
		foreach (Collider2D c in cs)
            c.enabled = false;

        Renderer[] rs = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
            r.enabled = false;
       // player.GetComponent<Renderer>().enabled = false;
        Instantiate (deathParticle, player.transform.position, player.transform.rotation);
		
        camera.isFollowing = false;
		gravityStore = player.GetComponent<Rigidbody2D> ().gravityScale;
		player.GetComponent<Rigidbody2D> ().gravityScale = 0f;
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		//ScoreManager.AddPoints (-pointPenaltyOnDeath);
		Debug.Log ("Player Respawn");
		yield return new WaitForSeconds (respawnDelay);
		player.GetComponent<Rigidbody2D> ().gravityScale = gravityStore;
		player.transform.position = currentCheckpoint.transform.position;
        player.knockbackCount = 0;
		player.enabled = true;

		
		Collider2D[] cs2 = player.GetComponentsInChildren<Collider2D>();
		foreach (Collider2D c in cs2)
            c.enabled = true;

        Renderer[] rs2 = player.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs2)
            r.enabled = true;

		
        player.GetComponent<BoxCollider2D>().enabled = true;
		player.GetComponent<CircleCollider2D>().enabled = true;
		player.GetComponentInChildren<Collider2D>().enabled = true;
        // player.GetComponent<Renderer> ().enabled = true;
        healthManager.FullHealth();
		healthManager.isDead = false;
		camera.isFollowing = true; 
		Instantiate (respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

	}
}
