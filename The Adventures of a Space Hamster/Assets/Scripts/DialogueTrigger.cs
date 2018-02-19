using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
	public DialogueManager dMan;
	public GameObject dBox;
	public GameObject dName;
	public GameObject dLog;
	public BoxCollider2D promptA;
	public DialogueTrigger self;

	public Animator prompt01;
	public GameObject prompt02;

	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
		self = GetComponent<DialogueTrigger> ();
		DtrigL ();

	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			TriggerDialogue ();

		}
	}

	public void TriggerDialogue () {
		dMan.StartDialogue (dialogue);
		StartD ();
	}

	public void StartD(){
		prompt01.SetBool ("dInProg", true);
		promptA.enabled = false;
		prompt02.gameObject.SetActive(true);
	}

	public void EndD(){
		prompt01.SetBool ("dInProg", false);
		promptA.enabled = true;
		prompt02.gameObject.SetActive (false);
	}

	public void DtrigL(){
		dMan.dTrig = self;
	}

}
