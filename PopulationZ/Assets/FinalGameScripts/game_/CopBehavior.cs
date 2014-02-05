using UnityEngine;
using System.Collections;

public class CopBehavior : MonoBehaviour {
	public enum State {wander, fight, flee}
	public enum Type {cop, swat, fbi, soldier};
	public Type type;
	public State state;
	public int health, armor, damage, bulletSpeed, targetDistanceAway;
	public float fireRate, timeTillNextShot;
	public bool infected, canShoot;
	public GameObject zombie, targetZombie, bullet;
	Vector3 wayPoint, bulletDirection;
	GameObject zombiestats;
	
	//waypoint
	GameObject ground;
		float groundXMin;
		float groundXMax;
		float groundZMin;
		float groundZMax;
		float groundY;

	// Use this for initialization
	void Start () {
		//grab coord from ground
		ground = GameObject.FindGameObjectWithTag("Ground");
		Vector3 buffer = ground.collider.bounds.size;
		//use buffer to make a square from center poin given above
		groundXMin = ground.transform.position.x - buffer.x /2;
		groundXMax = ground.transform.position.x + buffer.x /2;
		groundZMin = ground.transform.position.z - buffer.z /2;
		groundZMax = ground.transform.position.z + buffer.z /2;
		groundY = ground.transform.position.y+1;
		zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
		type = Type.cop; 
		state = State.wander;
		Wander();
		//zomPoint = wayPoint;
		canShoot = true;
		targetDistanceAway = 15;
		
		if(type == Type.cop)
		{
			timeTillNextShot = fireRate = 2.0f;
			armor = 0;
			bulletSpeed = 10;
			damage = 50;
			health = 200;
		}
		else if (type == Type.swat)
		{
			timeTillNextShot = fireRate = 1.5f;
			armor = 50;
			bulletSpeed = 10;
			damage = 30;
			health = 400;
		}
		else if (type == Type.fbi)
		{
			timeTillNextShot = fireRate = 0.75f;
			armor = 75;
			bulletSpeed = 10;
			damage = 50;
			health = 600;
		}
		else if (type == Type.soldier)
		{
			timeTillNextShot = fireRate = .5f;
			armor = 100;
			bulletSpeed = 10;
			damage = 100;
			health = 1000;
		}
		
		infected = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(targetZombie == null || 
			(targetZombie.transform.position.x - transform.position.x > targetDistanceAway && 
			targetZombie.transform.position.z - transform.position.z > targetDistanceAway))
		{
			state = State.wander;
			GetComponent<NavMeshAgent>().Resume();
		}
		
		if(canShoot == false)
		{
			timeTillNextShot -= Time.deltaTime;
			if (timeTillNextShot <= 0)
				canShoot = true;
		}
		
		if(state == State.wander)
		{
			int distanceAway = 5;
			if(((transform.position.x - wayPoint.x) < distanceAway) && ((transform.position.z - wayPoint.z) < distanceAway))
			{
				Wander();
			}
		} 
		if(state == State.fight)
		{
			if(canShoot == true)
				Shoot ();
		}
	}
	
	void Wander()
	{
		wayPoint.x = Random.Range(groundXMin, groundXMax);	
		wayPoint.z = Random.Range(groundZMin,groundZMax);	
		wayPoint.y = 10;
		
		GetComponent<NavMeshAgent>().destination  = wayPoint;
	}
	
	public void GetHurt(int dmg, bool infect)
	{
		health -= dmg - armor;
		if(infected == false)
			infected = infect;
		if(health <= 0 )
			Die();	
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
		Instantiate(zombie, transform.position, transform.rotation);
	}
	
	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "zombie")
		{
			
			GetComponent<NavMeshAgent>().Stop();
			
			//zomPoint = collision.gameObject.transform.position;
			targetZombie = collision.gameObject;
			transform.LookAt(targetZombie.transform.position);
			state = State.fight;
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "zombie")
		{
			collision.gameObject.GetComponent<ZombieBehavoir>().SentHurt(this.gameObject);
		}
	}
	
	void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.tag == "zombie")
		{
			collision.gameObject.GetComponent<ZombieBehavoir>().SentHurt(this.gameObject);
		}
	}
	
	void Shoot()
	{
		bulletDirection = targetZombie.transform.position -  transform.position;
		bulletDirection.Normalize();
		
		GameObject bull = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
		//bull.rigidbody.AddForce(transform.forward*5*Time.deltaTime);
		bull.GetComponent<BulletBehavior>().SetBullet(bulletSpeed, damage, bulletDirection);
		//print("bullet fired");
		
		//Instantiate(bullet, transform.position, transform.rotation);
		//bullBehave = GetComponent<BulletBehavior>().SetBullet(5, damage, bulletDirection);
		
		timeTillNextShot = fireRate;
		canShoot = false;
		
	}
}
