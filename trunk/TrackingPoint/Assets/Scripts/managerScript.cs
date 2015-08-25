using UnityEngine;
using System.Collections;

public class managerScript : MonoBehaviour 
{
	public bool customisation;

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
	}

}
