using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	public Transform Target;
	public Vector3 Offset;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		this.transform.position = Target.transform.position + Offset;
	}
}
