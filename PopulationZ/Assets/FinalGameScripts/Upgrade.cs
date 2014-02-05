using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {
	//public int currentHealth, currentDamage, currentDamageResistance, currentInfects, 
	public int upgradesAvailable;
	//public float currentLifeSpan, currentInfectChance, currentSpeed;
	GameObject zombiestats;
	
 
	// Use this for initialization
	void Start () 
	{
		zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
		upgradesAvailable = zombiestats.GetComponent<ZombieStats>().upgradePoints;
		/*currentHealth = 100;
		currentDamage = 50;
		currentDamageResistance = 0;
		currentInfects = 1;
		currentLifeSpan = 30;
		currentInfectChance = 50;
		currentSpeed = 5;
	*/
	}
	
	// Update is called once per frame
	void Update () {
		upgradesAvailable = zombiestats.GetComponent<ZombieStats>().upgradePoints;
		
		if(upgradesAvailable > 0)
		{
			if (Input.GetKeyDown (KeyCode.F1))
				UpgradeStat(1,1);
			if (Input.GetKeyDown (KeyCode.F2))
				UpgradeStat(2,1);
			if (Input.GetKeyDown (KeyCode.F3))
				UpgradeStat(3,1);
			if (Input.GetKeyDown (KeyCode.F4))
				UpgradeStat(4,1);
			if (Input.GetKeyDown (KeyCode.F5))
				UpgradeStat(5,1);
			if (Input.GetKeyDown (KeyCode.F6))
				UpgradeStat(6,1);
			if (Input.GetKeyDown (KeyCode.F7))
				UpgradeStat(7,1);	
		}
			
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			Application.LoadLevel("MenuSystem");
		}
		
	}
	
	void UpgradeStat(int option, int increaseAmount)
	{
		switch(option)
		{
			case 1:
			{
				
				zombiestats.GetComponent<ZombieStats>().health += 50 * increaseAmount;
				zombiestats.GetComponent<ZombieStats>().upgradePoints--;
				break;
			}
			case 2:
			{
				zombiestats.GetComponent<ZombieStats>().damage += 5* increaseAmount;
				zombiestats.GetComponent<ZombieStats>().upgradePoints--;
				break;
			}
			case 3:
			{
				zombiestats.GetComponent<ZombieStats>().damageResistance += 10* increaseAmount;
				zombiestats.GetComponent<ZombieStats>().upgradePoints--;
				break;
			}
			
			case 4:
			{
				zombiestats.GetComponent<ZombieStats>().setLifeSpan += 10.0f* increaseAmount;
				zombiestats.GetComponent<ZombieStats>().upgradePoints--;
				break;
			}
			case 5:
			{
				zombiestats.GetComponent<ZombieStats>().infectChance += 5.0f* increaseAmount;
				zombiestats.GetComponent<ZombieStats>().upgradePoints--;
				break;
			}
			case 6:
			{
				zombiestats.GetComponent<ZombieStats>().speed += 0.5f* increaseAmount;
				zombiestats.GetComponent<ZombieStats>().upgradePoints--;
				break;
			}
			case 7:
			{
				zombiestats.GetComponent<ZombieStats>().infects += 1* increaseAmount;
				zombiestats.GetComponent<ZombieStats>().infectsLeft = zombiestats.GetComponent<ZombieStats>().infects;
				zombiestats.GetComponent<ZombieStats>().upgradePoints--;
				break;
			}
		}
	}
	
	//void ApplyUpgrades()
	//{
		//zombieBehave.GetComponent<ZombieBehavoir>().health = currentHealth;
		//zombieBehave.GetComponent<ZombieBehavoir>().damage = currentDamage;
		//zombieBehave.GetComponent<ZombieBehavoir>().damageResistance = currentDamageResistance;
		//zombieBehave.GetComponent<ZombieBehavoir>().setLifeSpan = currentLifeSpan;
		//zombieBehave.GetComponent<ZombieBehavoir>().infectChance = currentInfectChance;
	//}
}
