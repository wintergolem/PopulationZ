using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {
	
	public int speed, damage;
	public Vector3 position, direction;
	float dt, lifeTime;
	GameObject zombie;

	// Use this for initialization
	void Start () {
		//speed = 15;
		//damage = 0;
		lifeTime = 5.0f;
		position = transform.position;
	}
	
	public void SetBullet(int nspeed, int ndamage, Vector3 ndirection)
	{
		direction = ndirection;
		
		speed = nspeed;
		damage = ndamage;
		//print("new damage = " + damage);
	}
	
	// Update is called once per frame
	void Update () {
		dt = Time.deltaTime;
		lifeTime -= dt;
		position = transform.position;
		
		position.x += direction.x*(float)speed*dt;
		position.z += direction.z*(float)speed*dt;
		//position.y = 1;
		gameObject.transform.position = position;
		
		if(lifeTime <= 0)
			Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "zombie")
		{
			//print ("speed at hit = " + speed);
			//print("hit a zombie and dealt "+ damage+ " damage" );
			zombie = collision.gameObject;
			zombie.GetComponent<ZombieBehavoir>().GetHurt(damage);
			Destroy(gameObject);
		}
	}
}
