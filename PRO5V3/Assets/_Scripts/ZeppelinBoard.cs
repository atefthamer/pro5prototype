using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZeppelinBoard : MonoBehaviour
{
    public TextMeshPro forestText;
    public TextMeshPro desertText;
    public TextMeshPro snowText;
    public TextMeshPro tropicalText;

    private GameObject tracker;

    void Start()
    {
        tracker = GameObject.FindGameObjectWithTag("Tracker");

        forestText.text = tracker.GetComponent<IslandTracker>().forestDone.ToString();
        desertText.text = tracker.GetComponent<IslandTracker>().desertDone.ToString();
        snowText.text = tracker.GetComponent<IslandTracker>().snowDone.ToString();
        tropicalText.text = tracker.GetComponent<IslandTracker>().tropicalDone.ToString();
    }
}
