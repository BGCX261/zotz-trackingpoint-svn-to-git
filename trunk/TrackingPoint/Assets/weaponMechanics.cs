using UnityEngine;
using System.Collections;

public class weaponMechanics : MonoBehaviour
{
	public GameObject MainCamera;

	public float scaleLimit = 0.0f;    
	public float z = 10f;

	public int bulletsFired;
	public float fireRate;


	void Start () 
	{
		MainCamera = GameObject.FindWithTag("MainCamera");
	}

	void Update () 
	{
		fireRate += Time.deltaTime;

		if(Input.GetKey (KeyCode.Mouse0) && bulletsFired == 0)
		{
			ShootRay();
			bulletsFired ++;
			fireRate = 0f;
		}

		else if(Input.GetKey (KeyCode.Mouse0) && fireRate >= 0.075f)
		{
			scaleLimit = 1;
			ShootRay();
			bulletsFired ++;
			fireRate = 0f;
		}

		if(Input.GetKeyUp(KeyCode.Mouse0))
		{
			bulletsFired = 0;
			scaleLimit = 0;
		}
	}

	void ShootRay()
	{
		float randomRadius = scaleLimit;             
		//  The Ray-hits will be in a circular area
		randomRadius = Random.Range( 0, scaleLimit );        
		float randomAngle = Random.Range ( 0, 2 * Mathf.PI );
		
		//Calculating the raycast direction
		Vector3 direction = new Vector3(randomRadius * Mathf.Cos( randomAngle ), randomRadius * Mathf.Sin( randomAngle ), z);

		direction = transform.TransformDirection( direction.normalized );

		Ray ray = new Ray (MainCamera.transform.position, direction);	
		RaycastHit hit;	
		Debug.DrawRay(ray.origin, ray.direction, Color.green, 5f);
	}
}
