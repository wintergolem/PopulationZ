using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {
	
	protected GameObject civi;
	protected bool paused;

	// Use this for initialization
	void Start () {
		civi = GameObject.FindGameObjectWithTag("c");
	}
	
	void OnPauseGame()
	{
		paused = true;
		Time.timeScale = 0;
	}
	
	void OnResumeGame()
	{
		paused = false;
		Time.timeScale = 1;
	}
	
	// Update is called once per frame	
	void Update() {
		if (Input.GetKey(KeyCode.P) == true)
		{
			OnPauseGame();
		}
		if(Input.GetKey(KeyCode.O) == true)
			OnResumeGame();
		if (paused == true)
		{
			this.gameObject.guiText.text = "Game Paused - o to Resume";
		}
		else if (paused == false)
		{
			this.gameObject.guiText.text = "";
		}
	}
}
