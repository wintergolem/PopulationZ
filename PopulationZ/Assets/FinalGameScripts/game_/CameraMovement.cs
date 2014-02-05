using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey("w"))
			Camera.main.transform.Translate(new Vector3(0.0f, 1.0f, 0.0f));
		if(Input.GetKey("s"))
			Camera.main.transform.Translate(new Vector3(0.0f, -1.0f, 0.0f));
		if(Input.GetKey("a"))
			Camera.main.transform.Translate(new Vector3(-1.0f, 0.0f, 0.0f));
		if(Input.GetKey("d"))
			Camera.main.transform.Translate(new Vector3(1.0f, 0.0f, 0.0f));
		if(Input.GetKey("q"))
			Camera.main.transform.Translate(new Vector3(0.0f, 0.0f, -1.0f));
		if(Input.GetKey("e"))
			Camera.main.transform.Translate(new Vector3(0.0f, 0.0f, 1.0f));
		if(Input.GetKey("r"))
			Camera.main.transform.Rotate(new Vector3(0.0f, 0.0f, 5.0f));
		
	}
}
