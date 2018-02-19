using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBubble : MonoBehaviour {

	public bool animating;
	private Animator Anim;
	public float xTime01;
	public float xTime02;
	public float value;

	private LevelManager iLM;


	void Start () {
		Anim = GetComponent<Animator> ();
		iLM = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "PopBox") {
			StartCoroutine ("PopBubble");
		}

		if (other.tag == "Player") {
			iLM.currentOxygen += value;
			StartCoroutine ("PopBubble");
		}
	}

	IEnumerator PopBubble () {
		Anim.SetBool ("beingPopped", true);
		animating = true;

		yield return new WaitForSeconds (xTime01);

		Anim.SetBool ("beingPopped", false);
		animating = false;
		Destroy (gameObject);
	}
}
