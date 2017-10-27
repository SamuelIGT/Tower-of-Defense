using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[Header ("Atributes")]
	public float turnSpeed = 10f;
	public float fireRate = 1f;
	public int damage = 1;
	public float range = 15f;
	public bool isStangePrioriser = false;
	public bool isUpDownPrioriser = false;


	[Header ("Link Fields")]
	public Transform target;
	//Just to seed on the editor if the when the target is getted
	public string enemyTAG = "Quark";
	public string bottomQuarkTag = "Quark_Bottom";
	public string topQuarkTag = "Quark_Top";
	public Transform partToRotate;
	public GameObject bulletPrefab;
	public Transform firepoint;

	private float fireCountDown = 0.0f;
	private Collider[] objectsInRange;
	private LayerMask enemyMask = 1 << 8;

	// Use this for initialization
	void Start ()
	{
		if (gameObject.tag.Equals ("AREA_DAMAGE_TOWER")) {
			InvokeRepeating ("UpdateTargetsInArea", 0.0f, 0.5f);
		} else {
			InvokeRepeating ("UpdateTarget", 0.0f, 0.5f);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (gameObject.tag.Equals ("AREA_DAMAGE_TOWER")) {
			if (fireCountDown <= 0) {

				HitArea ();//shot

				fireCountDown = 1f / fireRate;
			}
			fireCountDown -= Time.deltaTime;
		} else {
			if (target == null) {
				return;
			}
			Vector3 direction = target.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation (direction);
			Vector3 rotation = Quaternion.Lerp (partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
			partToRotate.rotation = Quaternion.Euler (0.0f, rotation.y, 0.0f);

			if (fireCountDown <= 0) {
				Shoot ();
				fireCountDown = 1f / fireRate;
			}
			fireCountDown -= Time.deltaTime;
		}
	}

	void Shoot ()
	{
		if (firepoint == null) {
			return;
		}

		GameObject bullet = Instantiate (bulletPrefab, firepoint.position, firepoint.rotation) as GameObject;
		Bullet bulletScript = bullet.GetComponent<Bullet> ();
		bulletScript.SetDamage (damage);

		if (bulletScript != null) {
			bulletScript.Seek (target);
		}
	}

	void HitArea ()
	{
		GameObject[] TopEnemies = GameObject.FindGameObjectsWithTag (topQuarkTag);
		if (objectsInRange.Length > 0) {
			foreach (Collider col in objectsInRange) {
				Enemy enemy = col.GetComponent<Enemy> ();
				if (enemy != null) {
					Debug.Log ("Enemies inside the area: " + objectsInRange.Length);
					enemy.Hit (damage);
				}
			}
		}
	}

	void UpdateTarget ()
	{
		GameObject[] bottomEnemies = GameObject.FindGameObjectsWithTag (bottomQuarkTag);
		if (bottomEnemies.Length > 0) {
			setClosestTarget (bottomEnemies);

		} else {

			GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemyTAG);
			setClosestTarget (enemies);
		}
	}

	private void setClosestTarget (GameObject[] gameObjectArray)
	{
		float shortestDistance = Mathf.Infinity;
		GameObject closestEnemy = null;

		foreach (GameObject enemy in gameObjectArray) {
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);

			if (distanceToEnemy < shortestDistance) {
				shortestDistance = distanceToEnemy;
				closestEnemy = enemy;
			}
		}

		if (closestEnemy != null && shortestDistance <= range) {
			target = closestEnemy.transform;
		} else {
			target = null;
		}
	}

	void UpdateTargetsInArea ()
	{
		
		objectsInRange = Physics.OverlapSphere (transform.position, range, enemyMask);
		/*foreach (Collider col in objectsInRange)
		{
			Enemy enemy = col.GetComponent<Enemy>();
			if (enemy != null) //Apply damage
			{
				//float proximity = (gameObject.transform.position - enemy.transform.position).magnitude;
				//float effect = 1 - (proximity / range);
				enemy.DecreaseLife(damage);
			}
		}*/
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);

	}
}
