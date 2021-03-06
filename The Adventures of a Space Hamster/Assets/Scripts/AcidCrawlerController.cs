using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidCrawlerController : MonoBehaviour {

	//Reference Variables
	private Rigidbody2D rb2d;
	public MovingEnemy mE;

	void Start () {
		//Finds the rigidbody of the object
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		if(rb2d.velocity == new Vector2(mE.moveSpeed, rb2d.velocity.y)){
			transform.localScale = new Vector2 (2f, 2f);
		} else if (rb2d.velocity == new Vector2(-mE.moveSpeed, rb2d.velocity.y)) {
			transform.localScale = new Vector2 (-2f, 2f);
		}


	}
}
