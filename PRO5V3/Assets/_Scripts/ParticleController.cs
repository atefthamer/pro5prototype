using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public Transform targetCamera;

    private void Update()
    {
        if (targetCamera != null)
        {
            transform.LookAt(targetCamera);
        }
    }
}
