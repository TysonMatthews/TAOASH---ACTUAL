﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float followAhead;
	public float smoothing;
	public float yMin;
	public float yMax;
	public float yMovement;


	private Vector3 targetPosition;

	void Start () {
		
	}
	
	void Update () {
		
	}

	void LateUpdate () {
		yMovement = Mathf.Clamp (target.transform.position.y, yMin, yMax);

		targetPosition = new Vector3 (target.transform.position.x, 0f, -10f);

		if (target.transform.localScale.x > 0f) {
			targetPosition = new Vector3 (targetPosition.x + followAhead, yMovement, targetPosition.z);
		} else {
			targetPosition = new Vector3 (targetPosition.x - followAhead, yMovement, targetPosition.z);
		}

		//transform.position = targetPosition;

		transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime);
	}
}
