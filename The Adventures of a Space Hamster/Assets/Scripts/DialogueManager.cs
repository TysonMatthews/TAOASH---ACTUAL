﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;

	public float typeSpeed;

	public Animator Anim;
	public DialogueTrigger dTrig;

	private Queue<string> sentences;

	void Start () {
		sentences = new Queue<string> ();
		dTrig = GetComponent<DialogueTrigger> ();
	}

	void Update () {
		/*If the continue button is
		 * pressed then it displays the next
		 * sentence*/
		if (Input.GetKeyDown(KeyCode.E)) {
			DisplayNextSentence ();
		}
	}

	public void StartDialogue (Dialogue dialogue) {

		Anim.SetBool ("IsOpen", true);

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence () {
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines();
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence (string sentence) {
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return new WaitForSeconds(typeSpeed);
		}
	}

	void EndDialogue() {
		Debug.Log ("End of Conversation");
		Anim.SetBool ("IsOpen", false);
		dTrig.EndD ();
	}
}
