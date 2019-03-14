using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial_Minigame : MonoBehaviour
{
    private float countdown = 10.0f;
    private float gameTimer = 60.0f;
    private bool startCountdown = false;

    [HideInInspector]
    public int score = 0;

    public TextMeshPro countdownText;
    public TextMeshPro minigameText;
    public TextMeshPro scoreText;

    private void Awake()
    {
        startCountdown = true;
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
    }

    void Update()
    {

        if (startCountdown == true)
        {
            countdown -= Time.deltaTime;
            countdownText.text = "" + countdown.ToString("f0");

            if (countdown <= 0.0f)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
                countdown = 0.0f;
                gameTimer -= Time.deltaTime;
                minigameText.text = "" + gameTimer.ToString("f0");
                scoreText.text = "" + score.ToString();

                if (gameTimer <= 0.0f)
                {
                    gameTimer = 0.0f;
                }
            }
        }
    }
}
