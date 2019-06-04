using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeppelinFlying : MonoBehaviour
{
    public GameObject zeppelin;
    public GameObject throttle;
    public GameObject elevation;

    public float speedRoty = 500.0f;
    public float speedPosy = 10.0f;
    public float speed = 1.0f;

    private float roty = 0.0f;
    private float posy = 0.0f;
    private float forwardspeed = 0.0f;

    void Update()
    {
        if (StartEngine.EngineRunning == true)
        {
            roty = (roty + (transform.localEulerAngles.z * speedRoty)) * Time.deltaTime;
            posy = (posy + (elevation.transform.position.z * speedPosy)) * Time.deltaTime;

            Debug.Log("ROTATION SPEED: " + roty);
            Debug.Log("ELEVATION SPEED: " + posy);

            zeppelin.transform.Rotate(0.0f, roty, 0.0f, Space.World);
            zeppelin.transform.Translate(0.0f, posy, 0.0f, Space.Self);

            forwardspeed = (throttle.transform.localEulerAngles.x * speed) * Time.deltaTime;

            Debug.Log("FORWARD SPEED: " + forwardspeed);

            zeppelin.transform.Translate(0.0f, 0.0f, forwardspeed, Space.Self);
        }
    }
}
