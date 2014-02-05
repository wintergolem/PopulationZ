using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = ((int)(Time.time)).ToString();
	}
}
