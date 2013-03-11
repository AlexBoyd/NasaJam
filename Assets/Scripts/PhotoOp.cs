using UnityEngine;
using System.Collections;

public class PhotoOp : MonoBehaviour {
	
	public float PhotoAngle;
	
	public GameObject SuccessContent;
	
	public GameObject VisMesh;
	
	// Use this for initialization
	void Start () {
		this.transform.Rotate(new Vector3(0,0,PhotoAngle));
		if(VisMesh == null)
		{
			VisMesh = (GameObject)this.gameObject.transform.FindChild("VisMesh").gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		
	}
	
	public void UnlockPhoto()
	{
		this.gameObject.collider.enabled = false;
		VisMesh.gameObject.renderer.enabled = false;
	}
}
