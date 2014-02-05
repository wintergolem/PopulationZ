using UnityEngine;
using System.Collections;

public class MouseHandling : MonoBehaviour {
	
	bool canSpawnZombies;
	RaycastHit hit;
	public GameObject zombie;
	GameObject zombiestats;

	// Use this for initialization
	void Start () {
		canSpawnZombies = true;
		zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
		zombiestats.GetComponent<ZombieStats>().infectsLeft = zombiestats.GetComponent<ZombieStats>().infects;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(canSpawnZombies == true && Input.GetMouseButtonDown(0))
		{
			//print ("I am clicking");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit))
			{
				
				//print("clicked ");
				//print (hit.collider.transform.tag.ToString());
				if(hit.collider.transform.tag == "c")
				{
					Destroy(hit.collider.gameObject);
					Instantiate(zombie, hit.collider.transform.position,  hit.collider.transform.rotation);
					zombiestats.GetComponent<ZombieStats>().infectsLeft--;
					
					if(zombiestats.GetComponent<ZombieStats>().infectsLeft <= 0)
						canSpawnZombies = false;
					//print("clicked civilian");
				}
				
			}
		
		}	
	}
}
