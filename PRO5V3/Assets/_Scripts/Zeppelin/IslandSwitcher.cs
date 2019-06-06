using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class IslandSwitcher : MonoBehaviour
{
    public GameObject player;
    public string sceneName;
    private GameObject islandTracker;
    private bool destroy = false;

    private void Start()
    {
        islandTracker = GameObject.FindGameObjectWithTag("Tracker");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zeppelin"))
        {
            Debug.Log("Collision Detected");
            islandTracker.GetComponent<IslandTracker>().lastIsland = sceneName;
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        Destroy(player);
        destroy = true;

        if (destroy == true)
        {
            destroy = false;
            GetComponent<SteamVR_LoadLevel>().Trigger();
        }
    }
}
