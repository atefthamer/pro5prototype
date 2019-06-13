using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandTracker : MonoBehaviour
{
    [HideInInspector]
    public string lastIsland;
    [HideInInspector]
    public bool zepTutDone;

    private void Start()
    {
        zepTutDone = false;
        lastIsland = "Startingpoint";
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
