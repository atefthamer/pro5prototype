using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateHingeJoint : MonoBehaviour 
{
	private GameObject collidingObject;


	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Hand") 
		{
			SetCollidingObject(other);
			ConnectHingeToHand();
			//Debug.Log ("In Hand");
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject) return;
	
		collidingObject = null;
		Destroy(GetComponent<HingeJoint>());
		//Debug.Log ("Released");
	}

	private void SetCollidingObject(Collider col)
	{
		if (collidingObject || !col.GetComponent<Rigidbody> ()) return;
	
		collidingObject = col.gameObject;
	}

	private void ConnectHingeToHand()
	{
		var joint = AddHingeJoint();
		joint.connectedBody = collidingObject.GetComponent<Rigidbody>();
		collidingObject.GetComponent<Rigidbody> ().isKinematic = true;
		//Debug.Log ("Connected");
	}

	//Eigenlijk moet er steeds in OnTriggerEnter een hingejoint worden aangemaakt. Dit vanwege het feit dat als break == true, de Hingejoint wordt gedestroyd
	private HingeJoint AddHingeJoint()
	{
		HingeJoint hj = gameObject.AddComponent<HingeJoint>();
		JointLimits limits = hj.limits;

		hj.anchor = new Vector3 (0.0f, 0.5f, 0.0f);
		hj.connectedAnchor = new Vector3 (0.0f, 4.0f, 0.0f);
		hj.breakForce = 0.01f;
		hj.breakTorque = 0.01f;
		limits.min = -45.0f;
		limits.max = 45.0f;
		hj.useLimits = true;
		hj.limits = limits; //JointLimits is a struct, therefore needs to be overwritten completely
		
		return hj;
	}
}
