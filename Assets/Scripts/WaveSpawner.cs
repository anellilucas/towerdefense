﻿using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {

	public Wave[] waves;
	public static int EnemiesAlive = 0;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	private int waveIndex = 0;

	void Update ()
	{
		if (EnemiesAlive > 0) 
		{
			return;
		}

		if (countdown <= 0f)
		{
			StartCoroutine (SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;
	}

	IEnumerator SpawnWave ()
	{
		Wave wave = waves [waveIndex];
		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy (wave.enemy);
			yield return new WaitForSeconds (1f / wave.rate);
		}
		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
		EnemiesAlive++;
	}

}
