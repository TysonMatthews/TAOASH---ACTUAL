using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	//How much the coin is worth
	public int coinValue;

	//Reference Variables
	private LevelManager iLM;
	public GameObject Camera;
	public AudioSource coinCollectNoise;

	void Start () {
		//Finds stated object
		iLM = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		//Adds coin(s) and destroys the attached object
		if (other.tag == "Player") {
			iLM.AddCoins (coinValue);
			Instantiate (coinCollectNoise, Camera.transform.position, Camera.transform.rotation);
			Destroy(gameObject);
		}
	}
}
