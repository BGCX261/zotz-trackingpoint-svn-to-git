using UnityEngine;
using System.Collections;

public class cameraRotation : MonoBehaviour {

	public float rotationSpeed = 180f;
	public float moveSpeed = 10f;
	public GameObject MainCamera;
	
	void Start () 
	{
		MainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	void Update () 
	{
		float pitch = Input.GetAxisRaw ("Mouse Y") * Time.deltaTime * rotationSpeed;

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
