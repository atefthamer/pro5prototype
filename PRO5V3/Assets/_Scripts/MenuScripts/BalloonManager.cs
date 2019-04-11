using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonManager : MonoBehaviour
{
    public List<GameObject> balloons = new List<GameObject>();

    public SceneSwitch sw;

    void Update()
    {
        if (BalloonController.pop == true)
        {
            sw.DestroyPlayer(3);
        }
    }
}
