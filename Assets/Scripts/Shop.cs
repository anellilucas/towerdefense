using UnityEngine;

public class Shop : MonoBehaviour {

	public TurretBluePrint standardTurret;
	public TurretBluePrint anotherTurret;
	public TurretBluePrint LaserBeamer;

	BuildManager buildManager;

	void Start ()
	{
		buildManager = BuildManager.instance;
	}

	public void SelectStandardTurret ()
	{
		Debug.Log ("Standard Turret Purchased");
		buildManager.SelectTurretToBuild(standardTurret);
	}

	public void SelectAnotherTurret ()
	{
		Debug.Log ("Another Turret Purchased");
		buildManager.SelectTurretToBuild(anotherTurret);
	}

	public void SelectLaserBeamer ()
	{
		Debug.Log ("Laser Beamer Purchased");
		buildManager.SelectTurretToBuild(LaserBeamer);
	}
}
