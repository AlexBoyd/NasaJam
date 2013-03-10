using UnityEngine;
using System.Collections;

public class GravityAttractor : MonoBehaviour {
	
	public GravityManager GM;
	public float PullStrength;
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GravityManager").GetComponent<GravityManager>();
		GM.GravityAttractorList.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Pull(GravityBody GB)
	{
		if(PullStrength == 0){Debug.LogWarning(this.gameObject.name + "Gravity Attractor Pull Strength is equal to zero!");}
		GB.Velocity +=  -(Vector3.Normalize(GB.transform.position - this.transform.position) * PullStrength)/GB.Mass;

	}
}
