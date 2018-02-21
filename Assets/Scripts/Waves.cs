using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour {

	public GameObject enemy;
	public Transform spawnPoint;

	public void unleashWave()
	{
		Instantiate (enemy, spawnPoint.position, spawnPoint.rotation);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
