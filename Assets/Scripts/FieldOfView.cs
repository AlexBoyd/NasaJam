using UnityEngine;
using System.Collections;

public class FieldOfView : MonoBehaviour 
{
	public GameObject Player;
	public GameObject Moon;
	
	private void Update()
	{
		Camera.mainCamera.transform.position = Player.transform.position + new Vector3(0,0, -(100 + Mathf.Sqrt((Player.transform.position - Moon.transform.position).sqrMagnitude)));
		Player.transform.localScale = Vector3.one *  Mathf.Pow(Mathf.Abs(Camera.mainCamera.transform.position.z/100),0.8f);
	}
	
	
}
