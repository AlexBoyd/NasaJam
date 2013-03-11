using UnityEngine;
using System.Collections;

public class TextureRotationFeker : MonoBehaviour {
	
	float offset;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		offset += Time.deltaTime /100;
		this.renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
		this.renderer.material.SetTextureOffset("_BumpMap", new Vector2(offset, 0));
	}
}
