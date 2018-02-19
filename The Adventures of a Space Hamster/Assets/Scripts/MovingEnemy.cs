using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

	public Transform startPoint;
	public Transform endPoint;

	public float moveSpeed;

	private Vector3 currentTarget;
	public Rigidbody2D rb2d;
	public GameObject enemy;

	void Start () {
		currentTarget = endPoint.position;
		rb2d.velocity = new Vector2 (moveSpeed, rb2d.velocity.y);
		enemy.transform.localScale = new Vector3 (-2f, 2f, 1f);
		Debug.Log ("Going to end point...");
	}

	void Update () {
		rb2d.transform.position = Vector3.MoveTowards (rb2d.transform.position, currentTarget, moveSpeed * Time.deltaTime);

		if(rb2d.transform.position == endPoint.position){
			currentTarget = startPoint.position;
			enemy.transform.localScale = new Vector3 (2f, 2f, 1f);
			Debug.Log ("Going to start point...");
		}

		if (rb2d.transform.position == startPoint.position){
			currentTarget = endPoint.position;
			enemy.transform.localScale = new Vector3 (-2f, 2f, 1f);
			Debug.Log ("Going to end point...");
		}

	}
}
