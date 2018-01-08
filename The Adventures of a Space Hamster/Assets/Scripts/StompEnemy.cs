using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompEnemy : MonoBehaviour {

	public Rigidbody2D rb2d;

	public float bounceForce;

	void Start () {
		rb2d = transform.parent.GetComponent<Rigidbody2D> ();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "Enemy") {
			Destroy (other.gameObject);

			rb2d.velocity = new Vector3 (rb2d.velocity.x, bounceForce, 0f);
		}
	}
}
