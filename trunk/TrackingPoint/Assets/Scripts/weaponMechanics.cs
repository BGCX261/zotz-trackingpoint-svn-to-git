using UnityEngine;
using System.Collections;

public class weaponMechanics : MonoBehaviour
{
	public GameObject MainCamera;

	public float scaleLimit = 0.0f;    
	public float z = 10f;

	public int bulletsFired;
	public float fireRate;

	public GameObject[] bulletImpacts;
	public GameObject gun;

	public Transform hitPoint;

	Animator anim;


	void Start () 
	{
		MainCamera = GameObject.FindWithTag("MainCamera");

		anim = gun.GetComponent<Animator>();
	}

	void Update () 
	{
		fireRate += Time.deltaTime;

		if(Input.GetKey (KeyCode.Mouse0) && bulletsFired == 0 && MainCamera.GetComponent<controllerScript>().customisation == false)
		{
			ShootRay();
			bulletsFired ++;
			fireRate = 0f;
		}

		else if(Input.GetKey (KeyCode.Mouse0) && fireRate >= 0.075f && MainCamera.GetComponent<controllerScript>().customisation == false)
		{
			scaleLimit = 0.3f;
			ShootRay();
			bulletsFired ++;
			fireRate = 0f;
		}

		if(Input.GetKeyUp(KeyCode.Mouse0))
		{
			bulletsFired = 0;
			scaleLimit = 0;
		}

		if(Input.GetKeyUp(KeyCode.R))
		{
			anim.SetBool("Reload", true);
		}
	}

	void LateUpdate()
	{
		anim.SetBool ("Reload", false);
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
		if(Physics.Raycast (ray, out hit))															
		{
			hitPoint = hit.transform;
			if(hit.collider)
			{
				int i = Random.Range(0, bulletImpacts.Length);
				Instantiate(bulletImpacts[i], hit.point, Quaternion.LookRotation(hit.normal));
			}

		}
		Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.green, 5f);
	}
}
