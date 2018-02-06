using UnityEngine;
using UnityEngine.UI;


public class Lives : MonoBehaviour {

	public Text livesText;

	void Update () {
		livesText.text = PlayerStats.Lives.ToString () + " Lives";
	}
}
