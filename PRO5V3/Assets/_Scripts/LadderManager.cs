using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class LadderManager : MonoBehaviour
{
    public GameObject player;
    public GameObject ladderTop;
    public float speed = 1.0f;
    private bool ladderGrab = false;
    private bool destroy = false;

    private void Update()
    {
        if (ladderGrab == true)
        {
            float climb = speed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, ladderTop.transform.position, climb);

            if (Vector3.Distance(player.transform.position, ladderTop.transform.position) < 1.0f)
            {
                ladderGrab = false;
                SwitchScene();
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("Collision Detected");
            ladderGrab = true;
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
