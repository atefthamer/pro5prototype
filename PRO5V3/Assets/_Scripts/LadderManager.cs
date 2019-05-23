using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LadderManager : MonoBehaviour
{
    public GameObject player;
    private bool destroy = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
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
            SteamVR_LoadLevel.Begin("Zeppelin", false, 1.0f, 255, 255, 255, 1);
        }
    }
}
