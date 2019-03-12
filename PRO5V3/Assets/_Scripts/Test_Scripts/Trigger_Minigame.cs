using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger_Minigame : MonoBehaviour
{
    public Material[] mats;
    private float countdown = 10.0f;
    private float gameTimer = 60.0f;
    private bool startCountdown = false;

    public TextMeshPro countdownText;

    void Start()
    {
        gameObject.GetComponent<Renderer>().material = mats[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCountdown();
        }

        if (startCountdown == true)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0.0f)
            {
                countdown = 0.0f;
                gameTimer -= Time.deltaTime;
            }
        }
    }

    void StartCountdown()
    {
        gameObject.GetComponent<Renderer>().material = mats[1];
        countdownText.text = " " + countdown.ToString("f0");
        startCountdown = true;
    }

    void StartMinigame()
    {

    }
}
