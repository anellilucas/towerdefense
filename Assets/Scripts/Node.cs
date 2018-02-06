using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
	private Renderer rend;
	private Color startColor;
	public Color notEnoughMoneColor;

	[Header("Optional")]
	public GameObject turret;

	BuildManager buildManager;

	void Start ()
	{
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	public Vector3 GetBuildPosition ()
	{
		return transform.position;
	}
		
	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;
			
		if (turret != null)
		{
			buildManager.SelectNode(this);
			return;
		}

		if (!buildManager.CanBuild)
			return;

		buildManager.BuildTurretOn(this);	
	}
		
	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

		if (!buildManager.CanBuild)
			return;

		if (buildManager.HasMoney) {
			rend.material.color = hoverColor;
		} else
		{
			rend.material.color = notEnoughMoneColor;
		}
		


		rend.material.color = hoverColor;
	}

	void OnMouseExit()
	{
		rend.material.color = startColor; 
	}
}
