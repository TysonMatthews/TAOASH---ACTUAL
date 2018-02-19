using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {


	public bool checkpointActive;

	//Reference Variables
	public LevelManager iLM;
	private Animator Anim;

	void Start () {
		//Finds the stated objects
		iLM = FindObjectOfType<LevelManager> ();
		Anim = GetComponent<Animator> ();
	}

	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other) {
		//If the player touches the object it sets their oxygen to full
		if (other.tag == "Player" && !checkpointActive) {
			Instantiate (iLM.iPlayer.checkpointSound, iLM.iPlayer.Camera.transform.position, iLM.iPlayer.Camera.transform.rotation);
				iLM.GetComponent<LevelManager> ().currentOxygen = 100;
				iLM.GetComponent<LevelManager> ().oxygenBarSlider.value = 100;
			}

		//Activates the checkpoint if the player touches the object
		if(other.tag == "Player") {
			checkpointActive = true;
			Anim.SetBool ("Active", true);
		}
	}
}
