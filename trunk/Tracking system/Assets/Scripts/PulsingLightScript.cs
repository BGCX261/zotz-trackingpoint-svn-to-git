using UnityEngine;
using System.Collections;

public class PulsingLightScript : MonoBehaviour 
{
	public Material glowPerc;
	public int GlowOffset;
	public float XOffset;
	public float YOffset;
	public float Scale;

	public float percOffset;
	public float XOffsetRandom;
	public float YOffsetRandom;
	public float ScaleRandom;

	public float Timer;
	float TimerReset;

	void Start () 
	{
		TimerReset = Timer;
	}

	void Update ()
	{
		glowPerc.SetFloat ("_perc1", percOffset );
		glowPerc.SetFloat ("_MovingLightX", (Mathf.Sin (Time.time) + 1) * XOffset );
		glowPerc.SetFloat ("_MovingLightY", (Mathf.Sin (Time.time) + 1) * YOffset );
		//glowPerc.SetFloat ("_LightScale", (Mathf.Sin (Time.time) + 1) * Scale);

		percOffset = (Mathf.Sin (Time.time) + 1) * GlowOffset;

		if(percOffset < 100)
		{
			percOffset = 100;
		}



		Timer -= Time.deltaTime;
		if(Timer <= 0)
		{
			XOffsetRandom = Random.Range (0, 100);
			YOffsetRandom = Random.Range (0, 100);
			ScaleRandom = Random.Range (0,100);
			Timer = TimerReset;
		}

		XOffset = Mathf.Lerp (XOffset, XOffsetRandom, Time.deltaTime);
		YOffset = Mathf.Lerp (YOffset, YOffsetRandom, Time.deltaTime);
		//glowPerc.SetFloat ("_LightScale", Mathf.Lerp (Scale, ScaleRandom, Time.deltaTime));

	}
}
