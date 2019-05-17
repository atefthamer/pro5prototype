using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslandSwitcher : MonoBehaviour
{
    public int index;
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
            SceneManager.LoadScene(index);
        }
    }
}
