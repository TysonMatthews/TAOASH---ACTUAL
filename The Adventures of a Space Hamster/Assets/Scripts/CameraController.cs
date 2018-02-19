using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	//Camera follow variables
	public GameObject target;
	public float followAhead;
	public float smoothing;
	public float yMin;
	public float yMax;
	public float yMovement;


	private Vector3 targetPosition;

	void LateUpdate () {
		//Tells the camera where it can move on the Y-axis
		yMovement = Mathf.Clamp (target.transform.position.y, yMin, yMax);

		//Tells the camera where the target position is
		targetPosition = new Vector3 (target.transform.position.x, 0f, -10f);

		//Flips the camera
		if (target.transform.localScale.x > 0f) {
			targetPosition = new Vector3 (targetPosition.x + followAhead, yMovement, targetPosition.z);
		} else {
			targetPosition = new Vector3 (targetPosition.x - followAhead, yMovement, targetPosition.z);
		}

		//Smooths the camera movement
		transform.position = Vector3.Lerp (transform.position, targetPosition, smoothing * Time.deltaTime);
	}
}
