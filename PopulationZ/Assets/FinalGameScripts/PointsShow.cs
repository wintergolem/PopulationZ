using UnityEngine;
using System.Collections;

public class PointsShow : MonoBehaviour {

	public int totalpoints;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.guiText.text = totalpoints.ToString(); //This takes the PointsNum GUIText object and changes its value to the total number of points the player has.
	}
}
