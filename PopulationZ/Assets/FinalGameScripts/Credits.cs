using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Escape))
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			Application.LoadLevel("MenuSystem");		
		}
	}
}
