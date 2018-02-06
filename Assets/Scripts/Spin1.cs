using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin1 : MonoBehaviour {

	public GameObject piramide;
	
	// Update is called once per frame
	void Update () {
		piramide.transform.Rotate (0, 1, 0);
	}
}
