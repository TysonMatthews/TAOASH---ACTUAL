using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	private LevelManager iLevelManager;
	public int damageToGive;

	void Start () {
		iLevelManager = FindObjectOfType<LevelManager> ();
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			iLevelManager.HurtPlayer (damageToGive);
		}
	}
}
