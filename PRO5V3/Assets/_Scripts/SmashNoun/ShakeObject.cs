using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{
    public float shake_speed = 1.0f;
    public float shake_intensity = 1.0f;
    public Vector3 originPosition;

    public bool isShaking = true;

    void Start()
    {
        originPosition = transform.position;
    }

    void Update()
    {
        //StartShakeForSeconds(6);
        //ShakeTheObject();

        //StartCoroutine(GoLeft(10));
    }
    IEnumerator ShakeForSetTime(float time)
    {

        ShakeTheObject();


        yield return new WaitForSeconds(time);


    }

    public void ShakeTheObject()
    {
        float step = shake_speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, originPosition + Random.insideUnitSphere, step);
    }

    //public float tenSec = 10;
    public bool timerRunning = true;
    int i;

    public void StartShakeForSeconds(float tenSec)
    {
        // if (ShakeThatObject)
        // {
        float time = 0.0f;
        while (time != tenSec)
        {
            // time += Time.smoothDeltaTime;
            time += (Time.deltaTime % 60);
            i++;
            Debug.Log(i + " Time " + time);
            if (tenSec <= time)
            {
                ShakeTheObject();
            }
            else
            {
                //Debug.Log("Done");
                transform.position = originPosition;
                //timerRunning = false;
                return;
            }
        }
        //}
    }

    public void StartShake(float time)
    {
        StartCoroutine(GoLeft(time));
    }

    //StartCoroutine(GoLeft());
    IEnumerator GoLeft(float time)
    {
        // This will wait 1 second like Invoke could do, remove this if you don't need it
        yield return new WaitForSeconds(1);


        float timePassed = 0;
        while (timePassed < time)
        {
            // Code to go left here
            ShakeTheObject();
            timePassed += Time.deltaTime;

            yield return null;
        }
    }
}
