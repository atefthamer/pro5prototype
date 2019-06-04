using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringConstraint : MonoBehaviour
{
    private float lockPos = 0.0f;

    private float minXRot = -15.0f;
    private float maxXRot = 15.0f;

    private float minZRot = -15.0f;
    private float maxZRot = 15.0f;

    void Update()
    {
        //if (transform.localEulerAngles.x < minXRot)
        //{
        //    transform.localEulerAngles = new Vector3(minXRot, lockPos, transform.localEulerAngles.z);
        //    GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //    GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        //}
        //else transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, lockPos, transform.localEulerAngles.z);

        //if (transform.localEulerAngles.x > maxXRot)
        //{
        //    transform.localEulerAngles = new Vector3(maxXRot, lockPos, transform.localEulerAngles.z);
        //    GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //    GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        //}
        //else transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, lockPos, transform.localEulerAngles.z);

        //if (transform.localEulerAngles.z < minZRot)
        //{
        //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, lockPos, minZRot);
        //    GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //    GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        //}
        //else transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, lockPos, transform.localEulerAngles.z);

        //if (transform.localEulerAngles.z > maxZRot)
        //{
        //    transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, lockPos, maxZRot);
        //    GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //    GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        //}
        //else transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, lockPos, transform.localEulerAngles.z);

        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);

        transform.localPosition = new Vector3(-5.036749e-05f, 0.388905f, -0.0006688571f);
    }
}
