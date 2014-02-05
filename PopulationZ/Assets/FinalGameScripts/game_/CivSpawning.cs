using UnityEngine;
using System.Collections;

public class CivSpawning : MonoBehaviour {
	public GameObject Civilian;
	public Vector3 wayPoint;
	public float groundXMin;
	public float groundXMax;
	public float groundZMin;
	public float groundZMax;
	public GameObject ground;
	
	// Use this for initialization
	void Start () {
		//find x and y values for spawn
		ground = GameObject.FindGameObjectWithTag("Ground");
		Vector3 buffer = ground.collider.bounds.size;
		groundXMin = ground.transform.position.x - buffer.x /2;
		groundXMax = ground.transform.position.x + buffer.x /2;
		groundZMin = ground.transform.position.z - buffer.z /2;
		groundZMax = ground.transform.position.z + buffer.z /2;
		
		for(int i = 0; i < 2; i++)
		{
			Spawn (i);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
				
	}
	
	//spawn
	public void Spawn(int i){
		//if(false){
		//wayPoint.x = Random.Range(groundXMin, groundXMax);	
		//wayPoint.z = Random.Range(groundZMin, groundZMax);	
		//wayPoint.y = ground.transform.position.y;
		//}
		//GameObject civilian;
		//civilian = (GameObject)
		Vector3 pos = transform.position;
		pos.x += 5 * (i-1);
		Instantiate(Civilian, pos, transform.rotation);
	}
}
