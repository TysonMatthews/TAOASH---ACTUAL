using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour {

	public Rigidbody2D rb2d;

	public float bounceForce;
	public PlayerController pC;
	public AudioSource enemyDeathNoise;
	public GameObject Camera;

	void Start () {
		rb2d = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "Enemy") {
			rb2d.velocity = new Vector3 (rb2d.velocity.x, bounceForce, 0f);
			Instantiate (pC.iLM.deathParticle, other.transform.position, other.transform.rotation);
			Instantiate (enemyDeathNoise, Camera.transform.position, Camera.transform.rotation);
			other.gameObject.SetActive(false);
			pC.iLM.AddCoins (1);
		}
	}
}
