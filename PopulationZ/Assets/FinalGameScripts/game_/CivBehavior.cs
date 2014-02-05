using UnityEngine;
using System.Collections;

public class CivBehavior : MonoBehaviour {
	
	public int health;
	public bool infected;
	public GameObject zombie;
	GameObject zombiestats;

	// Use this for initialization
	void Start () {
		zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
		health = 100;
		infected = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(health <= 0 )
			Die();		
	}
	
	public void GetHurt(int dmg, bool infect)
	{
		health -= dmg;
		if(infected == false)
			infected = infect;
	}
	
	void Die()
	{
		if(infected == true)
			SpawnZombie();
		
		zombiestats.GetComponent<ZombieStats>().currentpoints++;
			
		Destroy(gameObject);
	}
	
	void SpawnZombie()
	{
		
		//Zombie = GameObject.Find("zombiePrehabs");
		//if(Zombie == null)
		//	Zombie = GameObject.Find("Zombie(Clone)");
		//print (Zombie.ToString() );
		Instantiate(zombie, transform.position, transform.rotation);
	}
}
