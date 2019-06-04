﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class IslandSwitcher : MonoBehaviour
{
    public GameObject player;
    public ZeppelinSpawner zSpawn;
    private bool destroy = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zeppelin"))
        {
            Debug.Log("Collision Detected");
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
