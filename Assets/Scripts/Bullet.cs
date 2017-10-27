using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

	private Transform target;
	public float speed = 70f;
	public GameObject impactEffect;
	private int damage;
	// Use this for initialization
	void Start ()
	{
		
	}

	public void Seek (Transform target)
	{
		this.target = target;
	}

	public void SetDamage (int damage)
	{
		this.damage = damage;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (target == null) {
			Destroy (gameObject);
			return;
		}

		Vector3 direction = target.position - transform.position;
		float distanceThisFrame = speed * Time.deltaTime;

		if (direction.magnitude <= distanceThisFrame) {
			HitTarget ();
			return;
		}	

		transform.Translate (direction.normalized * distanceThisFrame, Space.World);
	}

	public void HitTarget ()
	{
		target.gameObject.GetComponent<Enemy> ().Hit (damage);
		if (impactEffect != null) {
			GameObject impactEffectIns = Instantiate (impactEffect, transform.position, transform.rotation) as GameObject;
			Destroy (impactEffectIns, 0.2f);
		}

		Destroy (gameObject);
	}
}
