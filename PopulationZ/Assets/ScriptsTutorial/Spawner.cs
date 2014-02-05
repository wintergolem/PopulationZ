using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject zombiePrefab;
	public int zombiesSpawned;
	GameObject player;
	public bool spawn =true;
	float max;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(spawn){
			Spawn ();	
		}
	}
	
	//spawn
	void Spawn(){
		Instantiate (zombiePrefab, transform.position, transform.rotation); //spawn on spawner location
		zombiesSpawned +=1;
		
	}
}
