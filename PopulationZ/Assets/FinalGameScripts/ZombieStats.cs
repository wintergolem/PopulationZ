using UnityEngine;
using System.Collections;

public class ZombieStats : MonoBehaviour 
{
	public int pointsTillUpgrade = 25;
	public int currentpoints = 0;
	public int upgradePoints = 1;
	
	public int infects = 1;
	public int infectsLeft = 1;
	
	public int health = 100;
	public int damageResistance = 0;
	public int damage = 20; //damage dealt
	public float speed = 3.5f;
	public float infectChance = 25;
	public float setLifeSpan = 30; //seconds
	
	void Start()
	{
	pointsTillUpgrade = 25;
	currentpoints = 0;
	upgradePoints = 1;
	
	infects = 1;
	
	health = 100;
	damageResistance = 0;
	damage = 10; //damage dealt
	speed = 3.5f;
	infectChance = 25;
	setLifeSpan = 30; //seconds
	}
	
	void Update () 
	{
		if(currentpoints >= pointsTillUpgrade)
		{
			currentpoints -= pointsTillUpgrade;
			upgradePoints++;
		}
	}
}
