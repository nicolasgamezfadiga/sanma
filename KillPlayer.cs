using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

	public LevelMAnager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelMAnager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == "player")
		{
			levelManager.RespawnPlayer();
		}
	}
}
