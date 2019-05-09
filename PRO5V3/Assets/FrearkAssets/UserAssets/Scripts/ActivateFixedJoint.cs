 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFixedJoint : MonoBehaviour 
{
	private FixedJoint Fxj;

	void Start () 
	{
		Fxj = GetComponent<FixedJoint>();
	}


	public void OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.name == "Hand") 
		{
			Fxj.connectedBody = other.gameObject.GetComponent<Rigidbody>();
			Fxj.breakForce = Mathf.Infinity;
			Fxj.breakTorque = Mathf.Infinity;
			Debug.Log ("In Hand");
		}
	}

	public void OnTriggerExit(Collider other)
	{
		Debug.Log("OnTriggerExit");
		Fxj.connectedBody = null;
		Debug.Log ("Out Hand");
	}
}
