using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Bowwow_Scoreboard : MonoBehaviour
{
    public TextMeshPro scoreText;

    public LoadLetters scoreGenerator;

    void Update()
    {
        scoreText.text = "Score: " + scoreGenerator.score.ToString("f0");
    }
}
