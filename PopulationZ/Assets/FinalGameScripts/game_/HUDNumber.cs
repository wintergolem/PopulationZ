using UnityEngine;
using System.Collections;

public class HUDNumber : MonoBehaviour {
	
	GameObject[] civilains;
	GameObject[] zombies;
	//Vector3 pos;
	
	// Use this for initialization
	void Start () {
		//pos = Camera.main.WorldToViewportPoint(transform.position);
		//guiText.transform.position = new Vector3(Screen.width +5, Screen.height -5, 0);
		//guiText.pixelOffset = new Vector2 (1000000,100000000);
	}
	
	// Update is called once per frame
	void Update () {
		civilains = GameObject.FindGameObjectsWithTag("c");
		zombies = GameObject.FindGameObjectsWithTag("zombie");
		//guiText.transform.position = new Vector3(Screen.width +5, Screen.height -5, 0);
		guiText.pixelOffset = new Vector2 (- Screen.width /2 +50,Screen.height /2 - 50);
		this.guiText.text = "Civilains = " + civilains.Length.ToString() + "\n Zombies = " + zombies.Length.ToString();
	}
}
