using UnityEngine;
using System.Collections;

public class controllerScript : MonoBehaviour 
{
	public bool toggleTxt = false;
	public bool customisation;
	public Camera customisationCamera;
	public Camera weaponCamera;


	void OnGUI()
	{
		if(customisation == true)
		{
			toggleTxt = GUI.Toggle(new Rect(10, 10, 100, 30), toggleTxt, "Invert Vertical Controls?");
		}
	}

	void Start()
	{
		customisation = false;
	}
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			customisation = !customisation;
		}

		if (customisation)
		{
			customisationCamera.enabled = true;
			weaponCamera.enabled = false;


		}

		if(customisation == false)
		{
			customisationCamera.enabled = false;
			weaponCamera.enabled = true;
		}
	}
}
