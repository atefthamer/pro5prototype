using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class IslandSwitcher : MonoBehaviour
{
    public string sceneName;
    public GameObject player;
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
            SteamVR_LoadLevel.Begin(sceneName, false, 0.5f, 255, 255, 255, 1);
        }
    }
}
