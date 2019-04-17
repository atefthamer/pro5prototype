using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    Component halo;

    private void Start()
    {
        halo = GetComponent("Halo");  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
        }
    }
}
