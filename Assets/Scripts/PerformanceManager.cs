using UnityEngine;
using System.Collections;

public class PerformanceManager : MonoBehaviour {
	
	ArrayList DeltaTimeList = new ArrayList();
	public float AverageDeltaTime = 0.03f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(DeltaTimeList.Count > 100)
		{
			DeltaTimeList.RemoveAt(0);
			DeltaTimeList.Add(Time.deltaTime);
		}
		else
		{
			DeltaTimeList.Add(Time.deltaTime);	
		}
		
		float sum = 0;
		foreach(float f in DeltaTimeList)
		{
				sum += f;
		}
		
		AverageDeltaTime = sum/DeltaTimeList.Count;
		
		
	
	
	}
}
