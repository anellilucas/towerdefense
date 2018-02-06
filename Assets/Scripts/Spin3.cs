using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin3 : MonoBehaviour {

	public GameObject bola;
	
	// Update is called once per frame
	void Update () {
		bola.transform.Rotate (0, 0, 1);
	}
}
