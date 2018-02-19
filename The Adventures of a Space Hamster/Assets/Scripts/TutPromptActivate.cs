using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutPromptActivate : MonoBehaviour {

	public GameObject Prompt;

	void Start () {
		//Sets the "E" prompt to inactive in the start
		Prompt.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other) {
		/*If the player comes within the boxcollider
		 * then it activates the "E" prompt*/
		if (other.tag == "Player") {
			Prompt.gameObject.SetActive (true);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		/*Disables the "E" prompt when the player
		 * leaves the boxcollider*/
		if (other.tag == "Player") {
			Prompt.gameObject.SetActive (false);
		}
	}
}
