using UnityEngine;
using System.Collections;

public class CopSpawning : MonoBehaviour {

	public GameObject Cop;
	public Vector3 wayPoint;
	
	// Use this for initialization
	void Start () {
		for(int i = 0; i < 3; i++)
			Spawn ();
	}
	
	// Update is called once per frame
	void Update () {
				
	}
	
	//spawn
	void Spawn(){
		//GameObject.FindGameObjectWithTag("c").GetComponent<CivMovement>().GetWaypoint();
		Instantiate(Cop, transform.position, transform.rotation);
	}
}
