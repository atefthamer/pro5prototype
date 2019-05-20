using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchTest : MonoBehaviour
{
    private int index;
    public ZeppelinSpawner zSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            index = 0;
            SceneManager.LoadScene(index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 1;
            zSpawn.lastScene = "Startingpoint";
            SceneManager.LoadScene(index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 2;
            zSpawn.lastScene = "SmashNoun-Beta";
            SceneManager.LoadScene(index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 3;
            zSpawn.lastScene = "slashcard";
            SceneManager.LoadScene(index);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 4;
            zSpawn.lastScene = "BoWow";
            SceneManager.LoadScene(index);
        }
    }
}
