using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationConstraint : MonoBehaviour
{
    //private float lockPos = 0.0f;

    private float minZPos = -0.08f;
    private float maxZPos = 0.07f;

    void Update()
    {
        if (transform.localPosition.z < minZPos)
        {
            transform.localPosition = new Vector3(-0.03065651f, 0.02139369f, minZPos);
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else transform.localPosition = new Vector3(-0.03065651f, 0.02139369f, transform.localPosition.z);

        if (transform.localPosition.z > maxZPos)
        {
            transform.localPosition = new Vector3(-0.03065651f, 0.02139369f, maxZPos);
            GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else transform.localPosition = new Vector3(-0.03065651f, 0.02139369f, transform.localPosition.z);
    }
}
