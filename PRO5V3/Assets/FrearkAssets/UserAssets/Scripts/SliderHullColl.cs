using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHullColl : MonoBehaviour 
{
	public bool InsideHull = false;
	private ActivateFixedJoint1 Afj;

	void Start () 
	{
		Afj = GameObject.Find ("Slider").GetComponent<ActivateFixedJoint1>();
	}

	public void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.name == "Hand") 
		{
			InsideHull = true;
			//Debug.Log ("OnTriggerEnter Hull");
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Hand") 
		{
			InsideHull = false;
			Afj.TouchedMin = false;
			Afj.TouchedMax = false;
			//Debug.Log ("OnTriggerExit Hull");
		}
	}
}
