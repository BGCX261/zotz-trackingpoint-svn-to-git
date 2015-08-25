using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public GameObject Player;
	public Material Target;
	public Material Target1;
	public Material BaseTargetDestroy;
	public Material ThisTargetDestroy;
	public bool isDestroyed;
	public float DestroyNum;

	public float ResetTimer;
	float ResetTimerReset;

	public float RendererTimer;
	float RendererTimerReset;

	void Start () 
	{
		Player = GameObject.Find ("Player");
		isDestroyed = false;
		ThisTargetDestroy = new Material (BaseTargetDestroy);
		RendererTimerReset = RendererTimer;
		ResetTimerReset = ResetTimer;

	}

	void Update ()
	{
		if(isDestroyed == true)
		{
			this.gameObject.renderer.material = ThisTargetDestroy;
			ThisTargetDestroy.SetFloat("_perc1", DestroyNum);
			DestroyNum ++;
			RendererTimer -= Time.deltaTime;
			if(RendererTimer <= 0)
			{
				this.gameObject.renderer.enabled = false;
				this.gameObject.GetComponent<BoxCollider>().enabled = false;
				ResetTimer -= Time.deltaTime;
			}
			if(ResetTimer <= 0)
			{
				this.gameObject.renderer.enabled = true;
				this.gameObject.GetComponent<BoxCollider>().enabled = true;
				isDestroyed = false;
				ThisTargetDestroy = new Material (BaseTargetDestroy);
				RendererTimer = RendererTimerReset;
				ResetTimer = ResetTimerReset;
				DestroyNum = 0;
			}
			//Destroy(this.gameObject, DestroyTime);
		}
		else
		{
			if(Player.GetComponent<PlayerScript>().Target == this.gameObject)
			{
				this.gameObject.renderer.material = Target1;
				this.gameObject.tag = "Target";
			}
			else
			{
				this.gameObject.renderer.material = Target;
				this.gameObject.tag = "Enemy";
			}
		}
	}
}
