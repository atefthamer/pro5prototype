using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewScore : MonoBehaviour
{
    public TargetManager tMan;
    public TextMeshPro scoreText;

    void Update()
    {
        scoreText.text = "Score: " + tMan.score.ToString("f0");
    }
}
