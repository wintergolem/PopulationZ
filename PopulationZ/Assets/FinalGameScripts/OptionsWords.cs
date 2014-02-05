using UnityEngine;
using System.Collections;

public class OptionsWords : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.R)){
			Destroy (GameObject.FindGameObjectWithTag("DontDestroy"));	
		}
		if(Input.GetKey (KeyCode.Escape)){
			Application.LoadLevel(0);	
		}
	}
}
