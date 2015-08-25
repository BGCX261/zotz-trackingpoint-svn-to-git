using UnityEngine;
using System.Collections;

public class gunRotation : MonoBehaviour {

	public Transform gunLocation;
	public float speed = 1f;

	void Start () 
	{
	
	}

	void LateUpdate () 
	{
		transform.position = gunLocation.position;

		transform.rotation = Quaternion.Slerp(transform.rotation, gunLocation.rotation, Time.deltaTime * speed);
	}
}
