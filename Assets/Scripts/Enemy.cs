using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;
	public float health = 100;
	public int value = 50;

	void Start()
	{
		speed = startSpeed;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;
		if (health <= 0)
		{
			Die ();
		}
	}

	public void Slow  (float amount)
	{
		speed = startSpeed * (1f - amount);
	}

	void Die ()
	{
		PlayerStats.Money += value;
		Destroy (gameObject);
	}
}