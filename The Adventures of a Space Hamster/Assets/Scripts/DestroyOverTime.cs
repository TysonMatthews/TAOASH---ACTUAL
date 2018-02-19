using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

	//THIS DESTROYS OBJECTS AFTER A SET AMOUNT OF TIME
	//FOR PARTICLE EFFECTS, ETC.
	public float lifeTime;

	void Start () {
		
	}
	
	void Update () {
		lifeTime = lifeTime - Time.deltaTime;

		if (lifeTime <= 0){
			Destroy (gameObject);
		}
	}
}
