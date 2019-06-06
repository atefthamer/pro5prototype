using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnLocation : MonoBehaviour
{
    private GameObject islandTracker;
    private string spawnLocation;

    public GameObject[] spawnPoints;

    void Start()
    {
        islandTracker = GameObject.FindGameObjectWithTag("Tracker");
        spawnLocation = islandTracker.GetComponent<IslandTracker>().lastIsland;

        if (spawnLocation == "Startingpoint")
        {
            this.gameObject.transform.position = spawnPoints[0].gameObject.transform.position;
        }
        else if (spawnLocation == "slashcard")
        {
            this.gameObject.transform.position = spawnPoints[1].gameObject.transform.position;
        }
        else if (spawnLocation == "SmashNoun-Beta")
        {
            this.gameObject.transform.position = spawnPoints[2].gameObject.transform.position;
        }
        else if (spawnLocation == "BoWow")
        {
            this.gameObject.transform.position = spawnPoints[3].gameObject.transform.position;
        }
    }
}
