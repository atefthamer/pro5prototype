using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toppertje : MonoBehaviour
{
    public RabControllerForest rabF;
    private bool bol = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && bol == false)
        {
            StartCoroutine(rabF.RabbitToppertje());
            bol = true;
        }
    }
}
