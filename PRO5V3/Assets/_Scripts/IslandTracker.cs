using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandTracker : MonoBehaviour
{
    [HideInInspector]
    public string lastIsland;
    [HideInInspector]
    public bool zepTutDone;
    [HideInInspector]
    public bool zepTutDone2;

    public int forestDone = 0;
    public int desertDone = 0;
    public int snowDone = 0;
    public int tropicalDone = 0;

    private void Start()
    {
        zepTutDone = false;
        zepTutDone2 = false;
        lastIsland = "Startingpoint";
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
