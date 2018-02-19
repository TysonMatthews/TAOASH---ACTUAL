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

	public LevelManager iLM;
	public Timer iTime;
	public ScoreManager iScore;
	public GameObject Camera;
	public AudioSource hurtSound;
	public AudioSource jumpSound;
	public AudioSource checkpointSound;


	void Start () {
		//Gets stated component
		rb2d = GetComponent<Rigidbody2D> ();
		Anim = GetComponent<Animator> ();
		iLM = FindObjectOfType<LevelManager> ();
		iScore = FindObjectOfType<ScoreManager> ();
		iTime = FindObjectOfType<Timer> ();


		respawnPosition = transform.position;

		iLM = FindObjectOfType<LevelManager> ();
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
			Instantiate (jumpSound, Camera.transform.position, Camera.transform.rotation);

		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if(other.tag == "DeathBox") {
			Instantiate (hurtSound, Camera.transform.position, Camera.transform.rotation);
			iLM.currentHealth = 0;
			iLM.Respawn ();
		}
		if(other.tag == "HurtBox") {
			Instantiate (hurtSound, Camera.transform.position, Camera.transform.rotation);
			rb2d.velocity = new Vector2 (rb2d.velocity.x, hurtJumpForce);
		}

		if(other.tag == "Checkpoint") {
			respawnPosition = new Vector3(other.transform.position.x, other.transform.position.y + 2f, 0f);
		}

		if (other.gameObject.tag == ("Finish")) {
			Instantiate (checkpointSound, Camera.transform.position, Camera.transform.rotation);
			Debug.Log ("Trigger");
			iScore.timeScorel01 = iTime.time;
			iLM.FinLevel();
		}
		if(other.tag == "TimeStart"){
			iTime.activated = true;
		}
	}

	void OnCollisionEnter2D (Collision2D other){
		if(other.gameObject.tag == "MovingPlatform"){
			transform.parent = other.transform;
		}
	}

	void OnCollisionExit2D (Collision2D other){
		if(other.gameObject.tag == "MovingPlatform"){
			transform.parent = null;
		}
	}
}
