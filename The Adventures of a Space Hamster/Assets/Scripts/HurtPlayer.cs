using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	//How much damage to give
	public int damageToGive;

	//Reference Variables
	private LevelManager iLM;

	void Start () {
		//Finds stated objects
		iLM = FindObjectOfType<LevelManager> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		//Hurts player if they touch attached object
		if (other.tag == "Player") {
			iLM.HurtPlayer (damageToGive);
		}
	}
}
