using UnityEngine;

using System.Linq;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour 
{
	public GameObject Player;
	
	public List<GameObject> Planets;
	
	public float VoyagerSize = 1;
	
	public float MaxDistance;
	public float MinDistance;
	
	
	
	
	private void LateUpdate()
	{
		Camera.mainCamera.transform.position = Player.transform.position + new Vector3(0,0, Mathf.Clamp(20000 * LogisticalDistance(), MinDistance, MaxDistance));
		Player.transform.localScale = Vector3.one * VoyagerSize * Mathf.Abs(Camera.mainCamera.transform.position.z/100);
	}
	
	private float LogisticalDistance()
	{
		float closestPlanet = Planets.Min((planet) => (Player.transform.position - planet.transform.position).sqrMagnitude);
		return 0.5f - (1/(1 + Mathf.Exp(Mathf.Pow(closestPlanet/6000000, 0.8f))));
	}

	
	
}
