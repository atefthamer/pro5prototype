using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinConstraints : MonoBehaviour
{
    public float xMin = -15f;
    public float xMax = 15f;

    void Update()
    {
        if (transform.localPosition.x < xMin)
        {
            transform.localPosition = new Vector3(xMin, transform.localPosition.y, transform.localPosition.z);
        }
        else transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);

        if (transform.localPosition.x > xMax)
        {
            transform.localPosition = new Vector3(xMax, transform.localPosition.y, transform.localPosition.z);
        }
        else transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
    }
}
