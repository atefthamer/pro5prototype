using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [HideInInspector]
    public Transform lookPoint = null;

    void Update()
    {
        transform.LookAt(lookPoint);
        //this.gameObject.transform.Rotate(0, 28, 0);
        transform.RotateAround(lookPoint.transform.position, new Vector3(0, 0.1f, 0), 0.1f);
    }
}
