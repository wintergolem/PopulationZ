using UnityEngine;
using System.Collections;

public class UpgradePointsHUD : MonoBehaviour {
	
	GameObject zombiestats;
	
	// Use this for initialization
	void Start () {
		zombiestats = GameObject.FindGameObjectWithTag("DontDestroy");
	
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = zombiestats.GetComponent<ZombieStats>().upgradePoints.ToString();
	
	}
}
