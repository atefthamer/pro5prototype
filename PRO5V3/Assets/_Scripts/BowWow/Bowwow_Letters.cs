using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bowwow_Letters : MonoBehaviour
{
    public TextMeshPro lettersText;

    public LoadLetters lettersGenerator;

    public string text = "";
    void Update()
    {
        
        if (lettersGenerator.useCharArray)
        {
            for(int i = 0; i < lettersGenerator.wordSplit.Length; i++)
            {
                //lettersGenerator.wordSplit.ToString()
                //text.Insert(i,lettersGenerator.wordSplit[i].ToString());
                //text += lettersGenerator.wordSplit[i].ToString();
                //=lettersGenerator.wordSplit[i]; 
                //Debug.Log("LETTER ()()()() " + lettersGenerator.wordSplit[i].ToString());

                //lettersText.SetText(lettersGenerator.wordSplit[i].ToString());
            }
            //Debug.Log("TEXT >> " + text);
            //lettersText.SetText(lettersGenerator.wordSplit.ToString());
            lettersText.SetCharArray(lettersGenerator.wordSplit);
        }      
    }
}
