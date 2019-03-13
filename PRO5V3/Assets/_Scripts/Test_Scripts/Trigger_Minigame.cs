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
    public TextMeshPro minigameText;

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
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            countdown -= Time.deltaTime;
            countdownText.text = " " + countdown.ToString("f0");

            if (countdown <= 0.0f)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                countdown = 0.0f;
                gameTimer -= Time.deltaTime;
                minigameText.text = " " + gameTimer.ToString("f0");

                if (gameTimer <= 0.0f)
                {
                    gameTimer = 0.0f;
                }
            }
        }
    }

    void StartCountdown()
    {
        gameObject.GetComponent<Renderer>().material = mats[1];
        startCountdown = true;
    }
}
