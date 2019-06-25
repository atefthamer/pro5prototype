using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLadder : MonoBehaviour
{
    public GameObject ladder;
    private GameObject tracker;

    private void Start()
    {
        tracker = GameObject.FindGameObjectWithTag("Tracker");
        tracker.GetComponent<IslandTracker>().forestDone++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            ladder.gameObject.SetActive(true);
        }
    }
}
