using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalRigidBodyConstraint : MonoBehaviour 
{
	public GameObject StangVert;
	public GameObject StangHor;

	public float minX = -0.3f;
	public float maxX = 0.3f;
	public float minZ = -0.3f;
	public float maxZ = 0.3f;

	private float lockPos = 0.0f;

	void Update () 
	{
		if(transform.localPosition.x < minX)
		{
			transform.localPosition = new Vector3(minX, lockPos, transform.localPosition.z);
			GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f,0.0f);
			GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f,0.0f);
		}
		else transform.localPosition = new Vector3 (transform.localPosition.x, lockPos, transform.localPosition.z);

		if(transform.localPosition.x > maxX)
		{
			transform.localPosition = new Vector3(maxX, lockPos, transform.localPosition.z);
			GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f,0.0f);
			GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f,0.0f);
		}
		else transform.localPosition = new Vector3 (transform.localPosition.x, lockPos, transform.localPosition.z);

		if(transform.localPosition.z < minZ)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, lockPos, minZ);
			GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f,0.0f);
			GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f,0.0f);
		}
		else transform.localPosition = new Vector3 (transform.localPosition.x, lockPos, transform.localPosition.z);

		if(transform.localPosition.z > maxZ)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, lockPos, maxZ);
			GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f,0.0f);
			GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f,0.0f);
		}
		else transform.localPosition = new Vector3 (transform.localPosition.x, lockPos, transform.localPosition.z);

		StangVert.transform.localPosition = new Vector3(transform.localPosition.x, 0.0f, 0.0f);
		StangHor.transform.localPosition = new Vector3(0.0f, 0.0f, transform.localPosition.z);
	}
}
