using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	public float pitchSpeed = -180f;
	public GameObject Player;

	public Texture2D Crosshair;

	void Start () 
	{
		Player = GameObject.Find ("Player");
	}

	void Update () 
	{
		Screen.showCursor = false;
		float Pitch = Input.GetAxis ("Mouse Y") * Time.deltaTime * pitchSpeed;
		transform.Rotate (new Vector3 (Pitch, 0, 0));

		float newPitch = transform.rotation.eulerAngles.x;
		if(newPitch > 180 && newPitch < 280)
		{
			newPitch = -80;
		}
		else if(newPitch > 80 && newPitch < 180)
		{
			newPitch = 80;
		}
		transform.rotation = Quaternion.Euler (newPitch, transform.rotation.eulerAngles.y, 0);
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(Screen.width/2 - 32, Screen.height/2 - 32, 64, 64), Crosshair);
	}
}
