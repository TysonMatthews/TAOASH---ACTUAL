using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Collider2D))]
public class Player : MonoBehaviour {

	float jumpHeight = 4;
	float timeToJumpApex = .4f;
	float jumpVelocity = 8;
	float moveSpeed = 6;
	float gravity = -10;
	Vector3 velocity;

	Controller2D controller;

	void Start () {
		controller = GetComponent<Controller2D> ();
	}
	
	void Update () {

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		velocity.x = input.x * moveSpeed;
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
