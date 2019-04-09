using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinMovement : MonoBehaviour
{
    public GameObject point;
    public Vector3 axis;
    public float angle;

    private void Update()
    {
        transform.RotateAround(point.transform.position, axis, angle);
    }
}
