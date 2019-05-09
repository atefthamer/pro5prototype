using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFixedJoint1 : MonoBehaviour 
{
	private FixedJoint Fxj;
	private SliderHullColl IH;

	public bool TouchedMin = false;
	public bool TouchedMax = false;
	public GameObject Min;
	public GameObject Max;

	public GameObject Hand;
	public Color colorTouch = new Color (0.0f, 1.0f, 0.0f);
	public Color colorNoTouch = new Color (1.0f, 0.0f, 0.0f);
	public Color colorNoHull = new Color (1.0f, 1.0f, 1.0f);
	public Color colorToMin = new Color (0.0f, 0.0f, 0.0f);


	void Start () 
	{
		Fxj = GetComponent<FixedJoint>();
		IH = GameObject.Find ("SliderHull").GetComponent<SliderHullColl>();
	}

	void Update()
	{
		if (IH.InsideHull == false) 
		{
			Fxj.connectedBody = null;
			Hand.GetComponent<Renderer> ().material.color = colorNoHull;
			//Debug.Log ("IH.InsideHull = false");
		} 
		else 
		{
			if (transform.position.z < (Min.transform.position.z + 0.5f) && transform.position.z >= Min.transform.position.z) 
			{
				colorToMin.r = 0.0f;
				colorToMin.g = ((transform.position.z + 3.5f))*2;
				colorToMin.b = 0.0f;

				//Hand.GetComponent<Renderer> ().material.color = colorToMin;
				Debug.Log ("Close to Min");
			}

			if (transform.position.z < Min.transform.position.z) 
			{
				transform.position = new Vector3 (0.0f, 0.0f, -3.0f);
				Fxj.connectedBody = null;
				TouchedMin = true;
				Hand.GetComponent<Renderer> ().material.color = colorNoTouch;
			}

			if (transform.position.z > Max.transform.position.z) 
			{
				transform.position = new Vector3 (0.0f, 0.0f, 3.0f);
				Fxj.connectedBody = null;
				TouchedMax = true;
				Hand.GetComponent<Renderer> ().material.color = colorNoTouch;
			}
		
			//Debug.Log ("IH.InsideHull = true");
			//Hand.GetComponent<Renderer> ().material.color = colorTouch;
		}


	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Hand" && TouchedMin == false && TouchedMax == false)	
		{
			Fxj.connectedBody = other.gameObject.GetComponent<Rigidbody>();
			Fxj.breakForce = Mathf.Infinity;
			Fxj.breakTorque = Mathf.Infinity;

			Hand.GetComponent<Renderer> ().material.color = colorTouch;
			//Debug.Log("OnTriggerEnter Slider");
		}
	}
}
