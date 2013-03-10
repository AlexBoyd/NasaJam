using UnityEngine;
using System.Collections;

public class FieldOfView : MonoBehaviour 
{
	public GameObject Player;
	public GameObject Moon;
	
	public float MaxDistance;
	public float MinDistance;
	
	
	private void Update()
	{
		Debug.Log(LogisticalDistance());
		Debug.Log((Player.transform.position - Moon.transform.position).sqrMagnitude);
		Camera.mainCamera.transform.position = Player.transform.position + new Vector3(0,0, 100 + 20000 * LogisticalDistance());
		Player.transform.localScale = Vector3.one *  Mathf.Pow(Mathf.Abs(Camera.mainCamera.transform.position.z/100),0.8f);
	}
	
	private float LogisticalDistance()
	{
		return 0.5f - (1/(1 + Mathf.Exp((Player.transform.position - Moon.transform.position).sqrMagnitude/6000000)));
	}
	
	
}
