//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR;

//public class MoveSliderWithRigthContr : MonoBehaviour
//{
//    private SteamVR_TrackedObject trackedObj;
//    private GameObject collidingObject;
//    private GameObject objectInHand;

//    private SteamVR_Controller.Device Controller
//    {
//        get { return SteamVR_Controller.Input((int)trackedObj.index); }
//    }

//    void Awake()
//    {
//        trackedObj = GetComponent<SteamVR_TrackedObject>();
//    }

//    void Update()
//    {
//        if (Controller.GetHairTriggerDown())
//        {
//            if (collidingObject)
//            {
//                if (collidingObject.name == "SliderSteer") GrabObject();
//            }
//        }

//        if (Controller.GetHairTriggerUp())
//        {
//            if (objectInHand)
//            {
//                if (objectInHand.name == "SliderSteer") ReleaseObject();
//            }
//        }
//    }



//    private void GrabObject()
//    {
//        objectInHand = collidingObject;
//        collidingObject = null;

//        var joint = AddFixedJoint();
//        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
//        objectInHand.GetComponent<Rigidbody>().isKinematic = false;
//    }

//    private void ReleaseObject()
//    {
//        if (GetComponent<FixedJoint>())
//        {
//            GetComponent<FixedJoint>().connectedBody = null;
//            Destroy(GetComponent<FixedJoint>());

//            //objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
//            //objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;

//            objectInHand.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
//            objectInHand.GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
//            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
//        }
//        objectInHand = null;
//    }

//    private FixedJoint AddFixedJoint()
//    {
//        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
//        fx.breakForce = 20000;
//        fx.breakTorque = 20000;
//        fx.enableCollision = true;
//        return fx;
//    }

//    public void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.name == "SliderSteer") SetCollidingObject(other);
//    }

//    public void OnTriggerStay(Collider other)
//    {
//        SetCollidingObject(other);
//    }

//    public void OnTriggerExit(Collider other)
//    {
//        if (!collidingObject)
//        {
//            return;
//        }

//        collidingObject = null;
//    }

//    private void SetCollidingObject(Collider col)
//    {
//        if (collidingObject || !col.GetComponent<Rigidbody>())
//        {
//            return;
//        }

//        collidingObject = col.gameObject;
//    }
//}
