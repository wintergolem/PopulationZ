using UnityEngine;
using System.Collections;

public class ZombieBehavoir : MonoBehaviour {
	//public enum State {wander, chase};
	public Vector3 target; //used in wander and to hold civ position
	
	
	//State state;
	GameObject[] civilians;

	GameObject zombiestats;
	
	//Stats from Menu
	public int health;// = 100;
	public int damageResistance;// = 0;
	public int damage;// = 50; //damage dealt
	//float speed = 50;
	public float infectChance;// = 50;
	public float setLifeSpan;// = 30; //seconds
	public float lifeSpan;

	public NavMeshAgent navAgent;
	public NavMeshPathStatus pathStatusC;
	
	
	
	// Use this for initialization
	void Start () {
		
		GameObject zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
		health = zombiestats.GetComponent<ZombieStats>().health;
		damageResistance = zombiestats.GetComponent<ZombieStats>().damageResistance;
		damage = zombiestats.GetComponent<ZombieStats>().damage;
		infectChance = zombiestats.GetComponent<ZombieStats>().infectChance;
		setLifeSpan = zombiestats.GetComponent<ZombieStats>().setLifeSpan;
		GetComponent<NavMeshAgent>().speed = zombiestats.GetComponent<ZombieStats>().speed;
				
		//state = State.wander;
		//start counting time alive
		lifeSpan = 0;
	}
	
	// Update is called once per frame
	void Update () {
		lifeSpan += Time.deltaTime;
		CheckIfDecayed();
		GrabCivilians();
		FindTarget();
		
	}
	
	void GrabCivilians(){
		civilians = GameObject.FindGameObjectsWithTag("c");	
	}
	void FindTarget(){
		if(civilians.Length == 0){
			Wander ();
			return;
		}
		else
		{
			System.Collections.Generic.List<float> distances = new System.Collections.Generic.List<float>();
			foreach( GameObject civil in civilians)
			{
					float distance = Vector3.Distance(this.transform.position, civil.transform.position);
					distances.Add (distance);
			}
			distances.Sort();
			//if civilian is close enough run to it
			//print (civilians.Length.ToString() );

			if(distances[0] <= 15)
			{
				foreach( GameObject civil in civilians)
				{
						if(Vector3.Distance(this.transform.position, civil.transform.position) == distances[0])
						{
							//state = State.chase;
							target = civil.transform.position;
							GetComponent<NavMeshAgent>().SetDestination(civil.transform.position);
							pathStatusC = GetComponent<NavMeshAgent>().pathStatus;
							return;
						}
					}
			}
			else
			{
				Wander ();
			}
		}
		
	} 
	
	public void GetHurt(int damage){
		if(damage - damageResistance >0){
			health -= damage - damageResistance;	
		}
		
		if(health <= 0){
			//die
			Destroy(gameObject);
		}
	}
	
	public void SentHurt(GameObject obj){
		//civilain needs a gethurt	
		bool infect = Infected();
		if(obj.gameObject.tag == "c"){
			if(obj.gameObject.name == "CivilianF(Clone)")
				obj.GetComponent<CivBehavior>().GetHurt(damage,infect);
			if(obj.gameObject.name == "Cop(Clone)")
				obj.GetComponent<CopBehavior>().GetHurt(damage,infect);
		}
	}
	
	bool Infected(){
		//pick a number between o and 100
		float infect = Random.Range(0,100);
		//if infect is equal to or below infectChance, return true
		if(infect <= infectChance)
			return true;
		else 
			return false;
	}
	
	void CheckIfDecayed(){
		if(lifeSpan >= setLifeSpan){
			Destroy(gameObject);	
		}
	}
	
	void Wander()
	{
		if( Vector3.Distance( target, transform.position ) < 15 || !navAgent.hasPath )
		{
			target = Random.insideUnitSphere*15;
			NavMeshHit hit = new NavMeshHit();
			if( NavMesh.SamplePosition( target , out hit, 500, -1) )
			{
				target = hit.position;
				navAgent.SetDestination( target );
			}
			else
			{
				print ( "Error: ZombieBehavior - Wander" );
			}
		}
		
		//GetComponent<NavMeshAgent>().destination  = wayPoint;
	}
}