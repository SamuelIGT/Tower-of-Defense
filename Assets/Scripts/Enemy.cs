using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed = 10f;
	public int life = 1;
	private Transform target;
	private int waypointIndex = 0;
	private GameStatusController gameStatusController;
	private Collider[] quarksAround;

	// Use this for initialization
	void Start ()
	{
		gameStatusController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameStatusController> ();
		target = Waypoints.waypoints [0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (gameStatusController.GetGameStarted ()) {
			Vector3 direction = target.position - transform.position;
			transform.Translate (direction.normalized * speed * Time.deltaTime);

			if (Vector3.Distance (transform.position, target.position) <= 0.4f) {
				getNextWaypoint ();
			}
			
			if (life <= 0) {
				Destroy (gameObject);
			}
			if (this.gameObject.CompareTag ("Quark_Strange")) {
				Physics.OverlapSphere (transform.position, range, enemyMask);
			}
		}
	}

	private void getNextWaypoint ()
	{
		if (waypointIndex == Waypoints.waypoints.Length - 1) {
			Destroy (gameObject);
			return;
		}

		waypointIndex++;
		target = Waypoints.waypoints [waypointIndex];

	}

	public void Hit (int damage)
	{
		life = life - damage;
		if (life <= 0) {
			Destroy (gameObject);	
		}
	}
}
