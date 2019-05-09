using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Min : MonoBehaviour 
{
	public bool InsideMin = false;


	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Slider") 
		{
			InsideMin = true;
			Debug.Log("OnTriggerEnter Min");
		}
	}

	public void OnTriggerStay(Collider other)
	{
		if(other.gameObject.name == "Slider") 
		{
			InsideMin = true;
			Debug.Log("OnTriggerStay Min");
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if(other.gameObject.name == "Slider") 
		{
			InsideMin = false;

			Debug.Log("OnTriggerExit Min");
		}
	}
}
