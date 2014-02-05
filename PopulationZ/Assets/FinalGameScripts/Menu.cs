//Menu System will have the following:
//1. Start/Continue
//2. Quit
//3. Options - Sound

using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public bool resetallvariables = false;
	protected bool paused = false;
	protected GameObject guitext2;
	protected GameObject guitext3;
	protected GameObject guitext4;
	public GameObject zombiestats;
	//protected GameObject guitext5;
	
	// Use this for initialization
	void Start () {
		
		
		if(GameObject.FindGameObjectWithTag("DontDestroy") == false)
			Instantiate(zombiestats , transform.position , transform.rotation);
        Time.timeScale = 1;
		resetallvariables = false;
		guitext2 = GameObject.FindGameObjectWithTag("guitext2");
		guitext3 = GameObject.FindGameObjectWithTag("guitext3");
		guitext4 = GameObject.FindGameObjectWithTag("guitext4");
		//guitext5 = GameObject.FindGameObjectWithTag("guitext5");
	}
	
	void WriteText()
	{
		//guitext2.gameObject.guiText.text = "Press F2 to Continue";
		//guitext3.gameObject.guiText.text = "Press F3 to view options";
		//guitext4.gameObject.guiText.text = "Press F4 to quit";
	}
	
	void ResetText()
	{
		//guitext2.gameObject.guiText.text = "";
		//guitext3.gameObject.guiText.text = "";
		//guitext4.gameObject.guiText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKeyDown (KeyCode.P) && paused == false)
		//{
		//	WriteText ();
		//	Time.timeScale = 0;
		//	paused = true;
		//}
		
		//if (paused == true)
		//{
		WriteText ();
		if (Input.GetKeyDown (KeyCode.F2) || Input.GetKeyDown(KeyCode.Escape))
		{
			//paused = false;
			ResetText ();
			guitext2.guiText.text= "Loading";
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			Application.LoadLevel("CityOneScene");
			//Time.timeScale = 1; //Unpause game
		}
		if (Input.GetKeyDown (KeyCode.F3))
		{
			
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			Application.LoadLevel(3);
			//Options menu
		}
		if (Input.GetKeyDown (KeyCode.F4))
		{
			Application.Quit ();
		}
	
		if (Input.GetKeyDown (KeyCode.F5))
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			Application.LoadLevel("UpgradeMenu");
		}
			
		if(Input.GetKey(KeyCode.F6))
		{
			DontDestroyOnLoad(GameObject.FindGameObjectWithTag("DontDestroy"));
			Application.LoadLevel("CreditScene");	
		}
		//}
	}
}
