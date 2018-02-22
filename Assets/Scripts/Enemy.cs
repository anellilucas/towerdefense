﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float startSpeed = 10f;
	[HideInInspector]
	public float speed;
	public float startHealth = 100;
	private float health;
	public int value = 50;

	[Header("Unity Stuff")]
	public Image healthBar;

	void Start()
	{
		speed = startSpeed;
		health = startHealth;
	}

	public void TakeDamage (float amount)
	{
		health -= amount;
		healthBar.fillAmount = health / startHealth;
			
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
		WaveSpawner.EnemiesAlive--;
		Destroy (gameObject);
	}
}