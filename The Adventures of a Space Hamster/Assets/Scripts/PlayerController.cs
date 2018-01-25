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
	public RaycastHit2D hit;
	public float dist;
	public Vector2 dir;
	public Vector2 dirDR;
	public Vector2 dirDL;

	//Get Components Section
	private Rigidbody2D rb2d;
	private Animator Anim;

	public Vector3 respawnPosition;

	public LevelManager iLevelManager;


	void Start () {
		//Gets stated component
		rb2d = GetComponent<Rigidbody2D> ();
		Anim = GetComponent<Animator> ();
<<<<<<< HEAD
<<<<<<< HEAD
		C2D = GetComponent<Controller2D> ();
		Plyr = GetComponent<Player> ();
=======

>>>>>>> parent of 14fc260... 1/24/18 - T

=======
>>>>>>> parent of 2210004... 1/22/18 - T

		respawnPosition = transform.position;

		iLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
<<<<<<< HEAD
<<<<<<< HEAD
		
=======
		//Checks if the player is touching the ground so that it can jump
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatIsGround);
=======
		//Sets the direction of the raycast to below the Player
		dir = Vector2.down;

		//Sets the direction of the raycast to be at the bottom diagonals of the player
		dirDR = new Vector2 (1f, -1f);
		dirDL = new Vector2 (-1f, -1f);

		//Draws a line to represent the raycasts
		Debug.DrawRay(gameObject.transform.position, dir*dist,Color.red);
		Debug.DrawRay(gameObject.transform.position, dirDR*dist,Color.red);
		Debug.DrawRay(gameObject.transform.position, dirDL*dist,Color.red);

		//Checks if the player is touching the ground so that it can jump
		if(Physics2D.Raycast(gameObject.transform.position,dir,dist,WhatIsGround)){
			isGrounded = true;
		} else if (Physics2D.Raycast(gameObject.transform.position, dirDR, dist, WhatIsGround)) {
			isGrounded = true;
		} else if (Physics2D.Raycast(gameObject.transform.position, dirDL, dist, WhatIsGround)) {
			isGrounded = true;
		} else {isGrounded = false;}
>>>>>>> parent of 14fc260... 1/24/18 - T

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

<<<<<<< HEAD
>>>>>>> parent of 2210004... 1/22/18 - T
=======
>>>>>>> parent of 14fc260... 1/24/18 - T
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
