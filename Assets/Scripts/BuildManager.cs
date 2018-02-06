using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	private TurretBluePrint turretToBuild;
	public GameObject standardTurretPrefab;
	public GameObject anotherTurretPrefab;
	public GameObject LaserBeamerPrefab;
	private Node selectedNode;
	public NodeUI nodeUI;

	public bool CanBuild { get { return turretToBuild != null; } }

	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void BuildTurretOn(Node node)
	{
		if (PlayerStats.Money < turretToBuild.cost)
		{
			Debug.Log ("Not enough money");
			return;
		}

		PlayerStats.Money -= turretToBuild.cost;

		GameObject turret = (GameObject)Instantiate (turretToBuild.prefab, node.GetBuildPosition (), Quaternion.identity);
		node.turret = turret;

		Debug.Log ("Turret built! Money left: " + PlayerStats.Money);
	}

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	public void SelectNode (Node node)
	{
		selectedNode = node;
		turretToBuild = null;
		nodeUI.SetTarget (node);
	}

	public void SelectTurretToBuild (TurretBluePrint turret)
	{
		turretToBuild = turret;
		selectedNode = null;
	}
}
