﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bowwow_Word : MonoBehaviour
{
    public TextMeshPro wordText;

    public LoadLetters wordGenerator;

    void Update()
    {
        //wordText.text = "Word: " + wordGenerator.wordToDisplay;
        if (wordGenerator.displayWord)
        {
            wordText.SetText("Word: " + wordGenerator.wordToDisplay);
        Debug.Log("DISPLAY THE WORD!! " + wordGenerator.wordToDisplay);
        }

    }
}
