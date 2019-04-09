using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bowwow_Letters : MonoBehaviour
{
    public TextMeshPro lettersText;

    public LoadLetters lettersGenerator;

    void Update()
    {
        lettersText.SetCharArray(lettersGenerator.wordSplit);
    }
}
