﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
	}

	public void StartDialogue (Dialogue dialogue) {
		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence () {
		if(sentences.Count == 0) {}
		EndDialogue ();
		return;
	}

	void EndDialogue() {
		Debug.Log ("End of Conversation");
	}
}
