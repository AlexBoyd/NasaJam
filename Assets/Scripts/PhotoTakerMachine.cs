using UnityEngine;
using System.Collections;

public class PhotoTakerMachine : MonoBehaviour {
	
	GameObject CurrentPhotoRegion;
	public GameObject Photoflash;
	
	// Use this for initialization
	void Start () {
		Photoflash = GameObject.Find("Photoflash");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Photoflash.renderer.enabled = false;
		GetPhotoInput();
	}
	
	public void GetPhotoInput()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			Photoflash.renderer.enabled = true;
			
			if(CurrentPhotoRegion != null)
			{
				//Compare Angle	
				ScorePhoto();
				
			}
			else
			{
				//Black Space	
				Debug.Log("Bad photo");
			}
			
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Enter Trigger");
		if(other.tag == "PhotoOp")
		{
			CurrentPhotoRegion = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == CurrentPhotoRegion)
		{
			CurrentPhotoRegion = null;	
		}
	}
	
	void ScorePhoto()
	{
		float Score = 100;
		Score -= (this.transform.rotation.eulerAngles.z - 180) - CurrentPhotoRegion.transform.rotation.eulerAngles.z;
		Score = Mathf.Clamp(Score,0,100);
		
		if(Score > 65)
		{
			CurrentPhotoRegion.SendMessage("UnlockPhoto");
		}
		
	}
}
