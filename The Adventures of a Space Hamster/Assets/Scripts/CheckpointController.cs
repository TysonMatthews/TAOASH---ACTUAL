using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

	public bool checkpointActive;


	public LevelManager iLM;

	private Animator Anim;

	void Start () {
		Anim = GetComponent<Animator> ();
	}

	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player" && !checkpointActive) {
				iLM.GetComponent<LevelManager> ().currentOxygen = 100;
				iLM.GetComponent<LevelManager> ().oxygenBarSlider.value = 100;
			}

		if(other.tag == "Player") {
			checkpointActive = true;
			Anim.SetBool ("Active", true);
		}
	}
}
