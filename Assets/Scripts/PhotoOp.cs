using UnityEngine;
using System.Collections;

public class PhotoOp : MonoBehaviour {
	
	public float PhotoAngle;
	
	public GameObject SuccessContent;
	
	 
	
	// Use this for initialization
	void Start () {
		this.transform.Rotate(new Vector3(0,0,PhotoAngle));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		
	}
}
