using UnityEngine;
using System.Collections;

public class CivCollision : MonoBehaviour
{
	//CivMovement civMove;
//	Vector3 zomPoint;
	//CivBehavior civBehave;
	
	void Start () {
		//civMove = gameObject.GetComponent<CivMovement>();
		//civBehave = gameObject.GetComponent<CivBehavior>();
		//zomPoint = gameObject.GetComponent<CivMovement>().ZombiePoint;
		
	}
	
	void OnTriggerEnter(Collider collision)
	{
		//Debug.Log ("name = " + collision.gameObject.tag);
		if(collision.gameObject.tag == "zombie")
		{
			//civMovement civMove;
			//civMove = gameObject.GetComponent<CivMovement>();
			//zomPoint= collision.gameObject.transform.position;
			gameObject.GetComponent<CivMovement>().Flee();
			//GetComponent<NavMeshAgent>().speed = 0;
			//civMove.speed = 0;
			//Debug.Log(civMove.speed + " and " + civMove.currentState);
		}
	}
	
	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("name = " + collision.gameObject.tag);
		if(collision.gameObject.tag == "zombie")
		{
			//CivMovement civMove;
			//civMove = gameObject.GetComponent<CivMovement>();
			//civMove.currentState = CivMovement.State.dead;
			//ZombieBehavoir zBehave;
			//zBehave = collision.gameObject.GetComponent<ZombieBehavoir>();
			//zBehave.SentHurt(this.gameObject);
			
			collision.gameObject.GetComponent<ZombieBehavoir>().SentHurt(this.gameObject);
			
			
			
			//civMove.speed = 0;
			//Debug.Log( "Exterminate!");
		}
		//check for collision on buildings
		
	}
	
	void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.tag == "zombie")
		{
			collision.gameObject.GetComponent<ZombieBehavoir>().SentHurt(this.gameObject);
		}
		
	}
	
	
	
}
