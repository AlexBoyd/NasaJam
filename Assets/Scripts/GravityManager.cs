using UnityEngine;
using System.Collections;

public class GravityManager : MonoBehaviour {
	
	public ArrayList GravityBodyList = new ArrayList();
	public ArrayList GravityAttractorList = new ArrayList();
	public PerformanceManager PM;
	public float FallOffPower;

	
	// Use this for initialization
	void Start () {
		PM = this.gameObject.GetComponent<PerformanceManager>();
	}
	
	// Update is called once per frame
	void Update () {
		PullGravityBodies();
	}
	
	public void PullGravityBodies()
	{
		
		foreach(GravityAttractor GA in GravityAttractorList)
		{
			foreach(GravityBody GB in GravityBodyList)
			{
				if(GA.gameObject != GB.gameObject)
				{
					GA.Pull(GB);	
				}
			}
		}
	}
}
