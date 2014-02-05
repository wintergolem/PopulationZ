using UnityEngine;
using System.Collections;

public class UpgradeMenuCode : MonoBehaviour {
	
	protected GameObject UTitleText;
	protected GameObject UPointsText;
	protected GameObject UPointsNumber;
	protected GameObject UText4;
	protected GameObject UText5;
	protected GameObject UText6;
	protected GameObject UText7;
	protected GameObject UText8;
	protected GameObject UText9;
	protected GameObject UText10;
	protected int optionselected = 1;
	
	// Use this for initialization
	void Start () {
		
		UTitleText = GameObject.FindGameObjectWithTag("utext1");
		UPointsText = GameObject.FindGameObjectWithTag ("utext2");
		UPointsNumber = GameObject.FindGameObjectWithTag ("utext3");
		UText4 = GameObject.FindGameObjectWithTag("utext4");
		UText5 = GameObject.FindGameObjectWithTag("utext5");
		UText6 = GameObject.FindGameObjectWithTag("utext6");
		UText7 = GameObject.FindGameObjectWithTag("utext7");
		UText8 = GameObject.FindGameObjectWithTag("utext8");
		UText9 = GameObject.FindGameObjectWithTag("utext9");
		UText10 = GameObject.FindGameObjectWithTag("utext10");
	}
	
	void TestWhatsActive()
	{
		if (optionselected == 1)
		{
			UText4.gameObject.guiText.fontStyle = FontStyle.BoldAndItalic;
		}
		else if (optionselected == 2)
		{
			UText5.gameObject.guiText.fontStyle = FontStyle.BoldAndItalic;
		}
		else if (optionselected == 3)
		{
			UText6.gameObject.guiText.fontStyle = FontStyle.BoldAndItalic;
		}
		else if (optionselected == 4)
		{
			UText7.gameObject.guiText.fontStyle = FontStyle.BoldAndItalic;
		}
		else if (optionselected == 5)
		{
			UText8.gameObject.guiText.fontStyle = FontStyle.BoldAndItalic;
		}
		else if (optionselected == 6)
		{
			UText9.gameObject.guiText.fontStyle = FontStyle.BoldAndItalic;
		}
		else if (optionselected == 7)
		{
			UText10.gameObject.guiText.fontStyle = FontStyle.BoldAndItalic;
		}
	}
	
	void RefreshText()
	{
		UText4.gameObject.guiText.fontStyle = FontStyle.Normal;
		UText5.gameObject.guiText.fontStyle = FontStyle.Normal;
		UText6.gameObject.guiText.fontStyle = FontStyle.Normal;
		UText7.gameObject.guiText.fontStyle = FontStyle.Normal;
		UText8.gameObject.guiText.fontStyle = FontStyle.Normal;
		UText9.gameObject.guiText.fontStyle = FontStyle.Normal;
		UText10.gameObject.guiText.fontStyle = FontStyle.Normal;
	}
	
	void WrapSelected()
	{
		if (optionselected > 7)
		{
			optionselected = 1;
		}
		else if (optionselected < 1)
		{
			optionselected = 7;
		}
	}
	
	void TestArrows()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			optionselected--;
		}
		else if (Input.GetKeyDown (KeyCode.DownArrow))
		{
			optionselected++;
		}
	}
	
	void TestEnter()
	{
		//Add the function that does the processing here
	}
	
	// Update is called once per frame
	void Update () {
		RefreshText();
		TestArrows ();
		WrapSelected ();
		TestWhatsActive();
		TestEnter ();
	}
}
