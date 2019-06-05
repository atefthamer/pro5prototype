using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandTracker : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
