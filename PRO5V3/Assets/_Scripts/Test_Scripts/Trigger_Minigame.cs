using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger_Minigame : MonoBehaviour
{
    // Temporary
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
