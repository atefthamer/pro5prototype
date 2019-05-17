using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointLookAt : MonoBehaviour
{
    public Transform zeppelin;

    void Update()
    {
        transform.LookAt(zeppelin);
        transform.Rotate(new Vector3(0, 270, 0));
    }
}
