using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public GameObject bola;
	
	// Update is called once per frame
	void Update () {
		bola.transform.Rotate (1, 1.2f, 1.1f);
	}
}
