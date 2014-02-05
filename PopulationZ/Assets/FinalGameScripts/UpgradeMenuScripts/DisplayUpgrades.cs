using UnityEngine;
using System.Collections;

public class DisplayUpgrades : MonoBehaviour {
	
	GameObject zombiestats;
	GameObject dmgResistTxt, dmgTxt, healthTxt, infectChanceTxt, infectsTxt, lifeSpanTxt, speedTxt;
	
	// Use this for initialization
	void Start () {
		zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
		dmgResistTxt = GameObject.FindGameObjectWithTag("DmgResistTag");
		dmgTxt = GameObject.FindGameObjectWithTag("DamageTag");
		healthTxt = GameObject.FindGameObjectWithTag("HealthTag");
		infectChanceTxt = GameObject.FindGameObjectWithTag("InfectChanceTag");
		infectsTxt = GameObject.FindGameObjectWithTag("InfectsTag");
		lifeSpanTxt = GameObject.FindGameObjectWithTag("LifeSpanTag");
		speedTxt = GameObject.FindGameObjectWithTag("SpeedTag");
		
	
	}
	
	// Update is called once per frame
	void Update () {
		dmgResistTxt.guiText.text = zombiestats.GetComponent<ZombieStats>().damageResistance.ToString();
		dmgTxt.guiText.text = zombiestats.GetComponent<ZombieStats>().damage.ToString();
		healthTxt.guiText.text = zombiestats.GetComponent<ZombieStats>().health.ToString();
		infectChanceTxt.guiText.text = zombiestats.GetComponent<ZombieStats>().infectChance.ToString();
		infectsTxt.guiText.text = zombiestats.GetComponent<ZombieStats>().infects.ToString();
		lifeSpanTxt.guiText.text = zombiestats.GetComponent<ZombieStats>().setLifeSpan.ToString();
		speedTxt.guiText.text = zombiestats.GetComponent<ZombieStats>().speed.ToString();
	}
}
