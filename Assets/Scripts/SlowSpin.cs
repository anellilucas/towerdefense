using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowSpin : MonoBehaviour {

	public GameObject estrela;

	// Update is called once per frame
	void Update () {
		estrela.transform.Rotate (1, 1, 1);
	}
}
