using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRotatesObject : MonoBehaviour 
{
	private GameObject otr;


	void Start () 
	{
		otr = GameObject.Find ("ObjectToRotate");
	}
	

	void Update () 
	{
		otr.transform.localEulerAngles = new Vector3(0.0f, 0.0f, transform.eulerAngles.z);


		/*
			De y en de z werken in transform.eulerAngles.?
			De x niet:
			Want als de Vive Controller rechtop wordt gehouden en verder wordt gedraaid treedt er Gimbal lock op

		*/


		//Debug.Log ("z = " +transform.eulerAngles.z);


	}
}
