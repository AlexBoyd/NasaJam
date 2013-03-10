using UnityEngine;
using System.Collections;

public class GravityBody : MonoBehaviour {
	
	public GravityManager GM;
	
	public Vector3 Velocity = Vector3.zero;
	public Vector3 RotVelocity = Vector3.zero;
	
	public float Mass;
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GravityManager").GetComponent<GravityManager>();
		GM.GravityBodyList.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}
	
	void Move()
	{
		Velocity.z = 0;
		if(Mass == 0){Debug.LogWarning(this.gameObject.name + "Gravity body Mass is equal to zero!");}
		this.transform.position += Velocity*Time.deltaTime;
		this.transform.Rotate(RotVelocity*Time.deltaTime,Space.Self);
	}
}
