using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousMovingEnemy : MonoBehaviour {

	//Movement Variables
	public float moveSpeed;
	private bool canMove;

	//Reference Variables
	public Rigidbody2D rb2d;

	void Start () {
		//Finds the rigidbody of the object
		canMove = false;
	}

	void Update () {
		/*If the object is within the camera's sightline 
		then it starts moving at a set velocity*/
		if(canMove) {
			rb2d.velocity = new Vector3 (-moveSpeed, rb2d.velocity.y, 0f);
		}
	}
	//Indicates if the object is on screen
	void OnBecameVisible () {
		canMove = true;
	}
}
