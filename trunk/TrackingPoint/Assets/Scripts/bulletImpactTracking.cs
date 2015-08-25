using UnityEngine;
using System.Collections;

public class bulletImpactTracking : MonoBehaviour 
{
	public GameObject weapon;

	void Update()
	{
		transform.LookAt (weapon.GetComponent<weaponMechanics> ().hitPoint);
	}
}
