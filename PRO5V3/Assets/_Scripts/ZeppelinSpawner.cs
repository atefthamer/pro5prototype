using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinSpawner : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject player;
    [HideInInspector]
    public string lastScene;

    private void Start()
    {
        lastScene = "Startingpoint";
    }

    private void OnEnable()
    {
        //lastScene = "Startingpoint";
        Debug.Log(lastScene);
        if (lastScene == "Startingpoint")
        {
            Debug.Log("LAST SCENE = " + lastScene);
            player.transform.position = spawnPoints[0].transform.position;
        }
        else if (lastScene == "SmashNoun-Beta")
        {
            Debug.Log("LAST SCENE = " + lastScene);
            player.transform.position = spawnPoints[1].transform.position;
        }
        else if (lastScene == "slashcard")
        {
            Debug.Log("LAST SCENE = " + lastScene);
            player.transform.position = spawnPoints[2].transform.position;
        }
        else if (lastScene == "BoWow")
        {
            Debug.Log("LAST SCENE = " + lastScene);
            player.transform.position = spawnPoints[3].transform.position;
        }
        else
        {
            return;
        }
    }
}
