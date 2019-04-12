using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherManager : MonoBehaviour
{
    public List<GameObject> launchers = new List<GameObject>();
    private GameObject currentLauncher;
    private int index;

    private void Start()
    {
        index = Random.Range(0, launchers.Count);
        currentLauncher = launchers[index];
        launchers[index].SetActive(true);
        print(currentLauncher.name);
    }

    public void NextLauncher()
    {
        foreach (GameObject obj in launchers)
        {
            obj.SetActive(false);
        }

        index = Random.Range(0, launchers.Count);
        currentLauncher = launchers[index];
        launchers[index].SetActive(true);
        print(currentLauncher.name);
    }
}
