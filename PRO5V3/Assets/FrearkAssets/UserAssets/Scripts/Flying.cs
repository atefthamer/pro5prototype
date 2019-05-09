//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR;

///*
//public class Flying : MonoBehaviour 
//{
//	public Transform head;

//	public SteamVR_TrackedObject leftHand;
//	public SteamVR_TrackedObject rightHand;

//	private bool isFlying = false;

//	void Update () 
//	{
//		//var lDevice = SteamVR_Controller.Input ((int)leftHand.index);
//		var rDevice = SteamVR_Controller.Input ((int)rightHand.index);

//		if(rDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
//		{
//			isFlying = !isFlying;
//		}

//		if(isFlying)
//		{

//			//Vector3 leftDir = leftHand.transform.position - head.position;
//			Vector3 rightDir = rightHand.transform.position - head.position;

//			Vector3 dir = rightDir;

//			transform.position = transform.position + dir * 0.1f;
//		}
//	}
//}
//*/

//public class Flying : MonoBehaviour 
//{
//	public Transform head;
//	public SteamVR_TrackedObject rightHand;
//	public float rotspeed = 0.25f;
//	public float movspeed = 0.4f;

//	private bool isFlying = false;

//	void Update () 
//	{
//		var rDevice = SteamVR_Controller.Input ((int)rightHand.index);

//		if(rDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
//		{
//			isFlying = !isFlying;
//		}

//		if(isFlying)
//		{
//			Vector3 targetPosDir = rightHand.transform.position - head.position;
//			Vector3 targetRotDir = rightHand.transform.position - head.position;

//			float rotstep = rotspeed * Time.deltaTime;
//			Vector3 rotDir = Vector3.RotateTowards(transform.forward, targetRotDir, rotstep, 0.0F);

//			rotDir.y = 0.0f;
//			//Debug.DrawRay(rightHand.transform.position, newDir, Color.red);

//			transform.rotation = Quaternion.LookRotation(rotDir);
//			transform.position = transform.position + targetPosDir * movspeed;
//		}
//	}
//}

