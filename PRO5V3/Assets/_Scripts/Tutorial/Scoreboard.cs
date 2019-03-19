using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshPro scoreText;
    public TextMeshPro timeText;

    public GoalMinigame scoreboard;

    void FixedUpdate()
    {
        SetScoreboardText();
    }

    void SetScoreboardText()
    {
        //scoreText.text = " " + scoreboard.score.ToString();
        //timeText.text = " " + scoreboard.time.ToString("f0");
    }
}
