using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 180f;
	public GameObject MainCamera;

	void Start () 
	{
		MainCamera = GameObject.FindWithTag("MainCamera");
	}

	void Update () 
	{
		if(MainCamera.GetComponent<controllerScript>().customisation == false)
		{
			float yaw = Input.GetAxisRaw ("Mouse X") * Time.deltaTime * rotationSpeed;
			transform.Rotate (new Vector3 (0f, yaw, 0f));

			float leftRight = Input.GetAxis ( "Horizontal" );
			float upDown = Input.GetAxis ( "Vertical" );
			transform.Translate (( Vector3.right * leftRight + Vector3.forward * upDown ) * Time.deltaTime * moveSpeed, Space.Self );
		}
	}
}
