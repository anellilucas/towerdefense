using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	private Transform target;
	public float range = 15f;
	public string enemyTag = "Enemy";
	public float fireRate = 1f;
	private float fireCountdown = 0f;
	public GameObject bulletPrefab;
	public Transform firePoint;
	private Enemy targetEnemy;

	[Header("Use Laser")]
	public bool useLaser = false;
	public LineRenderer lineRenderer;
	public int damageOverTime = 30;
	public float slowAmount = 0.5f;


	void Start ()
	{
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}
		
	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy> ();
		} else 
		{
			target = null;
		}
	}

	void Update ()
	{

		if (target == null)
		{
			if (useLaser)
			{
				if (lineRenderer.enabled)
					lineRenderer.enabled = false;
			}
			return;
		}

		if (useLaser) {
			Laser ();
		} else
		{
			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}
	}

	void Laser ()
	{
		targetEnemy.TakeDamage (damageOverTime * Time.deltaTime);
		targetEnemy.Slow (slowAmount);

		if (!lineRenderer.enabled)
			lineRenderer.enabled = true;

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);
	}

	void Shoot ()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null)
			bullet.Seek (target);
 	}
		
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
