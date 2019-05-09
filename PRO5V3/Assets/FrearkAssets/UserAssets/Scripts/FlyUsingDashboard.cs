using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUsingDashboard : MonoBehaviour 
{
	public GameObject Plane;
	public GameObject Fs;


	public float speedRoty = 50.0f;
	public float speedRotx = 50.0f;
	public float speed = 1.0f;

	private float roty = 0.0f;
	private float rotx = 0.0f;
	private float forwardSpeed = 0.0f;

	void Start () 
	{
		
	}
	

	void Update () 
	{
		if(StartButton.EngineRunning == true)
		{
			//Mathf.Clamp (transform.localPosition.x, -0.3f, 0.3f);
			//Mathf.Clamp (transform.localPosition.z, -0.3f, 0.3f);

			roty = (roty + (transform.localPosition.x * speedRoty)) * Time.deltaTime;
			rotx = (rotx + (transform.localPosition.z * speedRotx)) * Time.deltaTime;

			Plane.transform.Rotate (0.0f, roty, 0.0f, Space.World);
			Plane.transform.Rotate (rotx, 0.0f, 0.0f, Space.Self);

			forwardSpeed = (Fs.transform.localPosition.z * speed) * Time.deltaTime;
			Plane.transform.Translate (0.0f, 0.0f, forwardSpeed, Space.Self);
		}
	}
}
