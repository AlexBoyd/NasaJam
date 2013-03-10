using UnityEngine;
using System.Collections;

public class PlayerDriveInput : MonoBehaviour {
	
	public GravityBody PlayerGravityBody;
	Vector3 ThrustVector = Vector3.zero;
	public float ThrustStrength = 10;
	// Use this for initialization
	void Start () {
		PlayerGravityBody = this.gameObject.GetComponent<GravityBody>();
	}
	
	// Update is called once per frame
	void Update () {
		GetWASD();
	}
	
	public void GetWASD()
	{
		if(Input.GetKey(KeyCode.W))
		{
			Thrust(0,1);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			Thrust(-1,0);
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			Thrust(0,-1);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			Thrust(1,0);
		}
	}
	
	public void Thrust(float xForce, float yForce)
	{
		Debug.Log("Thrusting");
		ThrustVector.x = xForce;ThrustVector.y = yForce;
		PlayerGravityBody.Velocity += (ThrustVector*ThrustStrength)*Time.deltaTime;
	}
}
