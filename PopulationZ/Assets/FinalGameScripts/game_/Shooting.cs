using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	//Transform projectile;
	public GameObject projectile;
	public float bulletSpeed = 20;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){ // left ctrl
			GameObject clone;
			clone = (GameObject)
				Instantiate (
				projectile, 
				transform.position , 
				transform.rotation);
			//Add force to make it move
			clone.rigidbody.AddForce(clone.transform.forward * bulletSpeed *Time.deltaTime);
		}
	}
}
