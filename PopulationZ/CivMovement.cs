using UnityEngine;
using System.Collections;

public class CivMovement : MonoBehaviour
{
	public int speed;
	public Vector3 wayPoint;
	

	// Use this for initialization
	void Start ()
	{
		speed = 5;
		Wander();
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position += transform.TransformDirection(Vector3.forward)*speed*Time.deltaTime;
		
		
		if((transform.position - wayPoint).magnitude < 3)
		{
			Wander();
		}
	}
	
	void Wander()
	{
			wayPoint = Random.insideUnitSphere*47;
			wayPoint.y = 11;
		
			GetComponent<NavMeshAgent>().destination  = wayPoint;
		
			//transform.LookAt(wayPoint);
			Debug.Log(wayPoint + " and " + (transform.position - wayPoint).magnitude);
	}
}

