using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour {

	public GameObject oxygenbubble;
	public Transform spawnL;
	public float delayTime;
	public float spawnRate;
	public bool oxygenSpawning;
	private Animator Anim;

	void Start () {
		Anim = GetComponent<Animator> ();
	}

	void Update () {
		if(!oxygenSpawning) {
			oxygenS ();
			oxygenSpawning = true;
		}
	}

	void oxygenS (){
		StartCoroutine ("SpawningOxygen");
	}

	IEnumerator SpawningOxygen() {
		Anim.SetBool ("Making Oxygen", true);

		yield return new WaitForSeconds (delayTime);
		Anim.SetBool ("Making Oxygen", false);

		Instantiate (oxygenbubble, spawnL.transform.position, spawnL.transform.rotation);

		yield return new WaitForSeconds (spawnRate);
		oxygenSpawning = false;
	}
}