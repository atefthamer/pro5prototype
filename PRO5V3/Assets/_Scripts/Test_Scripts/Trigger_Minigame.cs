using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Minigame : MonoBehaviour
{
    public Material[] mats;
    private float timer = 10.0f;
    private bool startCountdown = false;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material = mats[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartMinigame();
        }

        if (startCountdown == true)
        {
            timer -= Time.deltaTime;
        }
    }

    void StartMinigame()
    {
        gameObject.GetComponent<Renderer>().material = mats[1];
        startCountdown = true;
    }
}
