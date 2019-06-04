using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationConstraint : MonoBehaviour
{
    private float lockPos = 0.0f;

    private float minXRot = 0.0f;
    private float maxXRot = 138.0f;

    void Update()
    {
        //if (transform.localEulerAngles.x < minXRot)
        //{
        //    transform.localEulerAngles = new Vector3(minXRot, lockPos, lockPos);
        //    //GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //    //GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        //}
        //else transform.localEulerAngles = new Vector3(transform.localRotation.x, lockPos, lockPos);

        //if (transform.localEulerAngles.x > maxXRot)
        //{
        //    transform.localEulerAngles = new Vector3(maxXRot, lockPos, lockPos);
        //    //GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        //    //GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        //}
        //else transform.localEulerAngles = new Vector3(transform.localRotation.x, lockPos, lockPos);

        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);

        transform.localPosition = new Vector3(-9.384676e-07f, 0.02357813f, -3.317891e-05f);
    }
}
