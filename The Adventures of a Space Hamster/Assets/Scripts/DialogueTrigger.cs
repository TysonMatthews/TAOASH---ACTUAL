using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public DialogueManager dMan;
	public GameObject dBox;
	public GameObject dLog;
	public GameObject contB;

	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
	}

	void Update () {
		if (Input.GetKeyDown("e")) {
			TriggerDialogue ();
		}
	}

	public void TriggerDialogue () {
		dMan.StartDialogue (dialogue);
	}

}
