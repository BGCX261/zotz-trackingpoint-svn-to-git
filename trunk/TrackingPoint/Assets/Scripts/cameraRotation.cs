using UnityEngine;
using System.Collections;

public class cameraRotation : MonoBehaviour {

	public float rotationSpeed = 180f;
	public float moveSpeed = 10f;
	public GameObject MainCamera;
	public Texture2D Crosshair;

	public Transform bulletImpactTracking;
	public float speed = 15f;
	
	void Start () 
	{
		MainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	void Update () 
	{
		if(MainCamera.GetComponent<controllerScript>().customisation == false)
		{
			float pitch = Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * rotationSpeed;

			float newPitch = transform.rotation.eulerAngles.x;
			//checks the angle of the camera
			if(newPitch > 180 && newPitch < 280)
			//if angle is too low
			{
				newPitch = -80;
				//reset pitch angle
			}
			else if(newPitch > 80 && newPitch < 180	)
				//if angle is too high
			{
				newPitch = 80;
				//reset pitch angle
			}

			transform.rotation = Quaternion.Euler (newPitch, transform.rotation.eulerAngles.y, 0);
	
			if(MainCamera.GetComponent<controllerScript>().toggleTxt == false)
			{
				transform.Rotate (new Vector3 (- pitch, 0f, 0f));
			}

			else if(MainCamera.GetComponent<controllerScript>().toggleTxt == true)
			{
				transform.Rotate (new Vector3 (pitch, 0f, 0f));
			}
		}

	}

	void OnGUI()
	{
		if(MainCamera.GetComponent<controllerScript>().customisation == false)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 32, Screen.height/2 - 32, 64, 64), Crosshair);
		}
	}
}
