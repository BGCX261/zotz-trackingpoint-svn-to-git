using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
	public float yawSpeed = 180f;
	public float moveSpeed = 10f;

	public GameObject Target;
	public GameObject MainCamera;
	public GameObject ImpactPoint;

	public AudioClip GunShot;
	public AudioClip TargetSound;
	public bool TrackOn;

	public GameObject[] ImpactPoints;



	void Start () 
	{
		MainCamera = GameObject.FindWithTag("MainCamera");
		TrackOn = false;
	}

	void Update () 
	{
		float yaw = Input.GetAxis ("Mouse X") * Time.deltaTime * yawSpeed;
		transform.Rotate (new Vector3 (0f, yaw, 0f));

		float FrontBack = Input.GetAxis ("Vertical") * Time.deltaTime;
		float LeftRight = Input.GetAxis ("Horizontal") * Time.deltaTime;
		Vector3 rightDir = MainCamera.transform.right;
		Vector3 frontDir = Vector3.Cross (rightDir, Vector3.up);
		rigidbody.MovePosition (transform.position + (rightDir * LeftRight + frontDir * FrontBack) * moveSpeed);

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			ImpactPoints = GameObject.FindGameObjectsWithTag("ImpactPoint");
			foreach(GameObject g in ImpactPoints)
			{
				Destroy(g.gameObject);
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			TrackOn = !TrackOn;
		}

		if(Input.GetKey(KeyCode.Mouse0))
		{
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit))
				{
					if(TrackOn == true)
					{
						if(hit.transform.gameObject.tag == "Target")
						{
							if(hit.transform.gameObject.GetComponent<EnemyScript>().isDestroyed == false)
							{
								//AudioSource.PlayClipAtPoint (GunShot, transform.position);
								hit.transform.gameObject.GetComponent<EnemyScript>().isDestroyed = true;
								GameObject DestroyImpactPoint = Instantiate (ImpactPoint, hit.point + (hit.normal * 0.1f), Quaternion.LookRotation(hit.normal)) as GameObject;
								Destroy(DestroyImpactPoint, 1f);
							}
						}
					}
					else if(TrackOn == false)
					{
						if(hit.transform.gameObject.tag == "Enemy")
						{
							if(hit.transform.gameObject.GetComponent<EnemyScript>().isDestroyed == false)
							{
								//AudioSource.PlayClipAtPoint (GunShot, transform.position);
								hit.transform.gameObject.GetComponent<EnemyScript>().isDestroyed = true;
								GameObject DestroyImpactPoint = Instantiate (ImpactPoint, hit.point + (hit.normal * 0.1f), Quaternion.LookRotation(hit.normal))as GameObject;
								Destroy(DestroyImpactPoint, 1f);
							}
						}
						else
						{
							Instantiate (ImpactPoint, hit.point + (hit.normal * 0.1f), Quaternion.LookRotation(hit.normal));
						}
					}
				}
		}

		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			if(TrackOn == true)
			{
				Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0));
				RaycastHit hit;
				if(Physics.Raycast(ray, out hit))
				{
					if(hit.transform.gameObject.name == "Enemy")
					{
						AudioSource.PlayClipAtPoint(TargetSound, transform.position);
						Target = hit.transform.gameObject;
					}
				}
			}
		}

	}
}
