using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutPromptActivate : MonoBehaviour {

	public GameObject Prompt;

	void Start () {
		Prompt.gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Prompt.gameObject.SetActive (true);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Player") {
			Prompt.gameObject.SetActive (false);
		}
	}
}
