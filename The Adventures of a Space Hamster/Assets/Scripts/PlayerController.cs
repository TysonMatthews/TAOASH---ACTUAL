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
		C2D = GetComponent<Controller2D> ();
		Plyr = GetComponent<Player> ();


		respawnPosition = transform.position;

		iLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
		
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
