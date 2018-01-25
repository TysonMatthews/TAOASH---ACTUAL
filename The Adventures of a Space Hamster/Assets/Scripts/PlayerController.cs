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
	private Animator Anim;

	public Vector3 respawnPosition;

	public LevelManager iLevelManager;
	public Controller2D C2D;
	public Player Plyr;


	void Start () {
		//Gets stated component
		Anim = GetComponent<Animator> ();
<<<<<<< HEAD
		C2D = GetComponent<Controller2D> ();
		Plyr = GetComponent<Player> ();

=======
>>>>>>> parent of 2210004... 1/22/18 - T

		respawnPosition = transform.position;

		iLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
<<<<<<< HEAD
		
=======
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

>>>>>>> parent of 2210004... 1/22/18 - T
		//Animations
		Anim.SetFloat ("Speed", Mathf.Abs (Plyr.velocity.x));
		Anim.SetBool ("Grounded", C2D.collisions.below);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "DeathBox") {
			iLevelManager.Respawn ();
		}

		if (other.tag == "Enemy") {
		Plyr.velocity = new Vector3 (Plyr.velocity.x, hurtJumpForce, Plyr.velocity.z);
		}

		if(other.tag == "Checkpoint") {
			respawnPosition = new Vector3(other.transform.position.x, other.transform.position.y + 2f, 0f);
		}
	}
}
