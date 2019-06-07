using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLadder : MonoBehaviour
{
    public GameObject ladder;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            ladder.gameObject.SetActive(true);
        }
    }
}
