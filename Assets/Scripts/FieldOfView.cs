using UnityEngine;
using System.Collections;

public class FieldOfView : MonoBehaviour 
{
	public GameObject Player;
	public GameObject Planet;
	
	public float VoyagerSize = 1;
	
	public float MaxDistance;
	public float MinDistance;
	
	
	
	
	private void FixedUpdate()
	{
		Debug.Log(LogisticalDistance());
		Debug.Log((Player.transform.position - Planet.transform.position).sqrMagnitude);
		Camera.mainCamera.transform.position = Player.transform.position + new Vector3(0,0, Mathf.Clamp(20000 * LogisticalDistance(), MinDistance, MaxDistance));
		Player.transform.localScale = Vector3.one * VoyagerSize * Mathf.Pow(Mathf.Abs(Camera.mainCamera.transform.position.z/100),0.8f);
	}
	
	private float LogisticalDistance()
	{
		return 0.5f - (1/(1 + Mathf.Exp(Mathf.Pow((Player.transform.position - Planet.transform.position).sqrMagnitude/6000000, 0.8f))));
	}
	
	
}
