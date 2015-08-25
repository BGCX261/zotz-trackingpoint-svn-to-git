using UnityEngine;
using System.Collections;

public class controllerScript : MonoBehaviour 
{
	public bool toggleTxt = false;

	void OnGUI()
	{
		toggleTxt = GUI.Toggle(new Rect(10, 10, 100, 30), toggleTxt, "Invert Vertical Controls?");
	}
}
