using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {
	public GameObject[] civilains;
	public GameObject[] zombies;
	GameObject zombiestats;
	
	// Use this for initialization
	void Start () {
		zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
	}
	
	// Update is called once per frame
	void Update () {
		civilains = GameObject.FindGameObjectsWithTag("c");
		zombies = GameObject.FindGameObjectsWithTag("zombie");
		
		if(civilains.Length <= 0)
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			zombiestats.GetComponent<ZombieStats>().upgradePoints++;
			
			Application.LoadLevel("MenuSystem");
		}
		if(zombies.Length <= 0 && zombiestats.GetComponent<ZombieStats>().infectsLeft <= 0)
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			zombiestats.GetComponent<ZombieStats>().infectsLeft = zombiestats.GetComponent<ZombieStats>().infects;
			Application.LoadLevel("MenuSystem");
		}
			
	}
}
