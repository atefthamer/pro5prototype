using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial_Scoreboard : MonoBehaviour
{
    //public TextMeshPro countdownText;
    public TextMeshPro minigameText;
    public TextMeshPro scoreText;

    public Tutorial_Minigame scoreboard;

    private void Update()
    {
        minigameText.text = " " + scoreboard.gameTimer.ToString("f0");
        scoreText.text = " " + scoreboard.score.ToString("f0");
    }
}
