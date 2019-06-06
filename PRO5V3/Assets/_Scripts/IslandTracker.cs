using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandTracker : MonoBehaviour
{
    [HideInInspector]
    public string lastIsland;

    private void Start()
    {
        lastIsland = "Startingpoint";
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
