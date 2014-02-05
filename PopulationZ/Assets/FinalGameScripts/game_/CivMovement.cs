using UnityEngine;
using System.Collections;

public class CivMovement : MonoBehaviour
{
	//public int speed;
	public Vector3 wayPoint;
	public Vector3 ZombiePoint;
	public enum State{wander, panic, dead};
	public float groundY;
	
	public State currentState = State.wander;
	
	float timeToMove = 0;
	//grab coord from ground
		GameObject ground;
		float groundXMin;
		float groundXMax;
		float groundZMin;
		float groundZMax;
	
	
	// Use this for initialization
	void Start ()
	{
		//grab coord from ground
		ground = GameObject.FindGameObjectWithTag("Ground");
		Vector3 buffer = ground.collider.bounds.size;
		//use buffer to make a square from center poin given above
		groundXMin = ground.transform.position.x - buffer.x /2;
		groundXMax = ground.transform.position.x + buffer.x /2;
		groundZMin = ground.transform.position.z - buffer.z /2;
		groundZMax = ground.transform.position.z + buffer.z /2;
		groundY = ground.transform.position.y;
		//speed = 2;
		Wander();
		ZombiePoint = wayPoint;
		
		//set to ignore collision with other civilians
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeToMove += Time.deltaTime;
		//transform.position += transform.TransformDirection(Vector3.forward)*speed*Time.deltaTime;
		
		if(currentState == State.wander)
		{
			int distanceAway = 5;
			if(((transform.position.x - wayPoint.x) < distanceAway) && ((transform.position.z - wayPoint.z) < distanceAway))
			{
				Wander();
				timeToMove = 0;
			}
			//or if it's time to move
			if(timeToMove >= 15){
				timeToMove = 0;
				Wander();
			}
		}
		else if(currentState == State.panic)
		{
			int distanceAway = 5;
			if(((transform.position.x - wayPoint.x) < distanceAway) && ((transform.position.z - wayPoint.z) < distanceAway))
			{
				currentState = State.wander;
				GetComponent<NavMeshAgent>().speed = 3.5f;
				GetComponent<NavMeshAgent>().acceleration = 8f;
				GetComponent<NavMeshAgent>().angularSpeed = 120f;
				Wander();
			}
		}
		else
		{
			
		}
	}
	
	void Wander()
	{
	
		
			//randomly get values within paramaiters grabbed above
			wayPoint.x = Random.Range(groundXMin, groundXMax);	
			wayPoint.z = Random.Range(groundZMin, groundZMax);	
			wayPoint.y = ground.transform.position.y;
			//set destination
			GetComponent<NavMeshAgent>().SetDestination(wayPoint);
			
		
	}
	
	public void Flee()
	{
		currentState = State.panic;
		GetComponent<NavMeshAgent>().speed = 3.5f;
		GetComponent<NavMeshAgent>().acceleration = 8f;
		GetComponent<NavMeshAgent>().angularSpeed = 120f;
		
		if(transform.position.x <= ZombiePoint.x)
			wayPoint.x = Random.Range(groundXMin, ZombiePoint.x);
		else
			wayPoint.x = Random.Range(ZombiePoint.x, groundXMax);
		
		if(transform.position.z <= ZombiePoint.z)
			wayPoint.z = Random.Range(groundZMin, ZombiePoint.z);
		else
			wayPoint.z = Random.Range(ZombiePoint.z, groundZMax);
		
		wayPoint.y = groundY;
		//GetComponent<NavMeshAgent>().destination  = wayPoint;
		
	}
	
	public Vector3 GetWaypoint(){
		//randomly get values within paramaiters grabbed above
		wayPoint.x = Random.Range(groundXMin, groundXMax);	
		wayPoint.z = Random.Range(groundZMin, groundZMax);	
		wayPoint.y = groundY;
		return wayPoint;
	}
	
}

