using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public Text timeText;
	public float time;
	public bool activated;


	void Start () {
		activated = false;
	}
	
	void Update () {
		if (!activated){
			time = 0;
			timeText.text = "00 : 00 : 00";
		} else if (activated) {
			time += Time.deltaTime;
			var minutes = time / 60;
			var seconds = time % 60;
			var fraction = (time * 100) % 100;

			timeText.text = string.Format ("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction);
		}
	}
}
