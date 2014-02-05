using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public Transform targetObject;
	public Transform target;
	// Use this for initialization
	void Start () {
		targetObject = GameObject.Find("First Person Controller").transform;
		//target = GameObject.Find("Swat").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(target == null)
			GetComponent<NavMeshAgent>().destination = targetObject.transform.position;
		else
			GetComponent<NavMeshAgent>().destination = target.transform.position;
	}
}
