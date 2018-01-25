using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	//Movement Speeds Section
	private float speed;
	public float walkSpeed;
	public float runSpeed;
	public float jumpForce;
	public float hurtJumpForce;

	//Variables to check if player is grounded
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask WhatIsGround;
	public bool isGrounded;

	//Get Components Section
	private Rigidbody2D rb2d;
	private Animator Anim;

	public Vector3 respawnPosition;

	public LevelManager iLevelManager;


	void Start () {
		//Gets stated component
		rb2d = GetComponent<Rigidbody2D> ();
		Anim = GetComponent<Animator> ();


		respawnPosition = transform.position;

		iLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
		//Checks if the player is touching the ground so that it can jump
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatIsGround);

		//Walking Mechanics
		if(Input.GetAxisRaw ("Horizontal") > 0f) {
			rb2d.velocity = new Vector3 (speed, rb2d.velocity.y, 0f);
			transform.localScale = new Vector3 (1f, 1f, 1f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {
			rb2d.velocity = new Vector3 (-speed, rb2d.velocity.y, 0f);
			transform.localScale = new Vector3 (-1, 1f, 1f);
		} else {
			rb2d.velocity = new Vector3 (0f, rb2d.velocity.y, 0f);
		}

		Jump ();

		//Animations
		Anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));
		Anim.SetBool ("Grounded", isGrounded);
	}

	void FixedUpdate () {

		speed = walkSpeed;

		//Running Mechanics
		if (Input.GetKey ("left shift")) {
				speed = runSpeed;
		}
	}

	void Jump () {
		//Jumping Mechanics
		if(Input.GetButtonDown ("Jump") && isGrounded) {
			rb2d.velocity = new Vector3 (rb2d.velocity.x, jumpForce, 0f);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "DeathBox") {
			iLevelManager.Respawn ();
		}

		if(other.tag == "Enemy") {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, hurtJumpForce);
		}

		if(other.tag == "Checkpoint") {
			respawnPosition = new Vector3(other.transform.position.x, other.transform.position.y + 2f, 0f);
		}
	}
}
