using UnityEngine;
using System.Collections;

public class PlayerDriveInput : MonoBehaviour {
	
	public GravityBody PlayerGravityBody;
	
	Vector3 ThrustVector = Vector3.zero;
	Vector3 RotVector = Vector3.zero;
	
	public float RotationAccelerationSpeed;
	public float MaxRotationSpeed;
	public float ThrustStrength;
	
	
	
	public ParticleSystem ForwardThrustEmitter;
	public ParticleSystem ClockwiseThrustEmitter;
	public ParticleSystem CounterClockwiseThrustEmitter;
	
	// Use this for initialization
	void Start () {
		PlayerGravityBody = this.gameObject.GetComponent<GravityBody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		ForwardThrustEmitter.enableEmission = false;
		ClockwiseThrustEmitter.enableEmission = false;
		CounterClockwiseThrustEmitter.enableEmission = false;
		
		GetWASD();
	
		
	}
	
	public void GetWASD()
	{
		if(Input.GetKey(KeyCode.W))
		{
			Thrust(1);
		}
		
		if(Input.GetKey(KeyCode.A))
		{
			RotThrust(1);
			CounterClockwiseThrustEmitter.enableEmission = true;
		}
		
		if(Input.GetKey(KeyCode.S))
		{
			//Thrust(-1);
		}
		
		if(Input.GetKey(KeyCode.D))
		{
			RotThrust(-1);
			ClockwiseThrustEmitter.enableEmission = true;
		}
	}
	
	public void Thrust(float ForwardForce)
	{
		ForwardThrustEmitter.enableEmission = true;
		
		//ThrustVector = this.transform.forward * ForwardForce;
		ThrustVector = Vector3.right * ForwardForce;
		ThrustVector = Quaternion.Euler(0, 0, this.transform.rotation.eulerAngles.z) * ThrustVector;

		PlayerGravityBody.Velocity += (ThrustVector*ThrustStrength)*Time.deltaTime;
	}
	
	public void RotThrust(float z)
	{
		
		RotVector.z = z;
		PlayerGravityBody.RotVelocity += (RotVector*RotationAccelerationSpeed)*Time.deltaTime;
		PlayerGravityBody.RotVelocity.z = Mathf.Clamp(PlayerGravityBody.RotVelocity.z,-MaxRotationSpeed,MaxRotationSpeed);
	}
	

}
