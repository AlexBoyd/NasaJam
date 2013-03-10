using UnityEngine;
using System.Collections;

public class GravityManager : MonoBehaviour {
	
	public ArrayList GravityBodyList = new ArrayList();
	public ArrayList GravityAttractorList = new ArrayList();
	
	// Use this for initialization
	void Start () {
	
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
