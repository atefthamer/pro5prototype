using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class IslandSwitcher : MonoBehaviour
{
    //public string sceneName;
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
            //zSpawn.lastScene = sceneName;
            //SteamVR_LoadLevel.Begin(sceneName, false, 0.5f, 255, 255, 255, 1);
            //SteamVR_LoadLevel.Begin(sceneName);
            GetComponent<SteamVR_LoadLevel>().Trigger();
        }
    }
}
