using UnityEngine;
using System.Collections;

public class ReportDistance : MonoBehaviour {
	
	public Transform targetObject;
	
	// Use this for initialization
	void Start () {
		targetObject = GameObject.Find("First Person Controller").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(targetObject){
		//	float dist = Vector3.Distance (targetObject.position, this.transform.position);
			//print ("Distance to target is: " + dist);
		}
	}
}
