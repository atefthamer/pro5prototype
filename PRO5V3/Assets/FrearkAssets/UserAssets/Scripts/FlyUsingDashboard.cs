using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyUsingDashboard : MonoBehaviour 
{
	public GameObject Plane;
	public GameObject Fs;

	public float speedRoty = 50.0f;
	public float speedPosy = 10.0f;
	public float speed = 1.0f;

    public float maxTiltAngle = 15.0f;
    Vector3 curRot;
    float maxX = 0.099f;
    float minX = -0.099f;

    private float roty = 0.0f;
	private float posy = 0.0f;
	private float forwardSpeed = 0.0f;

	void Start () 
	{
        //curRot = Plane.transform.eulerAngles;
        //maxX = curRot.x + maxTiltAngle;
        //minX = curRot.x - maxTiltAngle;
        //Debug.Log("MAX ROTATION: " + maxX);
        //Debug.Log("MIN ROTATION: " + minX);
    }
	

	void Update () 
	{
        //Debug.Log("CURRENT LOCAL ROTATION: " + Plane.transform.localRotation.x);
        //Debug.Log("CURRENT ROTATION: " + Plane.transform.rotation.x);
        //Debug.Log("CURRENT ROTATION: " + this.transform.rotation);

        if (StartButton.EngineRunning == true)
		{
			//Mathf.Clamp (transform.localPosition.x, -0.3f, 0.3f);
			//Mathf.Clamp (transform.localPosition.z, -0.3f, 0.3f);

			roty = (roty + (transform.localPosition.x * speedRoty)) * Time.deltaTime;
			posy = (posy + (transform.localPosition.z * speedPosy)) * Time.deltaTime;
            //rotx = Mathf.Clamp(rotx, minX, maxX);

            Plane.transform.Rotate (0.0f, roty, 0.0f, Space.World);
			Plane.transform.Translate (0.0f, posy, 0.0f, Space.Self);

			forwardSpeed = (Fs.transform.localPosition.z * speed) * Time.deltaTime;
			Plane.transform.Translate (0.0f, 0.0f, forwardSpeed, Space.Self);

            //curRot.x = Mathf.Clamp(curRot.x, minX, maxX);

            //Plane.transform.eulerAngles = curRot;
        }

        //if (Plane.transform.eulerAngles.x > 20 )
        //{

        //}

        //if (Plane.transform.localRotation.x > 0.1f)
        //{
        //    Debug.Log("MAX ROTATION REACHED");
        //    speedRotx = 0.0f;
        //    Plane.transform.rotation = new Quaternion(0.099f, Plane.transform.localRotation.y, Plane.transform.localRotation.z, Plane.transform.localRotation.w);
        //}
        //else if (Plane.transform.localRotation.x < -0.1f)
        //{
        //    Debug.Log("MIN ROTATION REACHED");
        //    speedRotx = 0.0f;
        //    Plane.transform.rotation = new Quaternion(-0.099f, Plane.transform.localRotation.y, Plane.transform.localRotation.z, Plane.transform.localRotation.w);
        //}
        //else
        //{
        //    speedRotx = 30.0f;
        //}
    }
}
