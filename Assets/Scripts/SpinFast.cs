using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinFast : MonoBehaviour {

	public GameObject bola;
	
	// Update is called once per frame
	void Update () {
		bola.transform.Rotate (0.1f, 0.2f, 0.3f);
	}
}
