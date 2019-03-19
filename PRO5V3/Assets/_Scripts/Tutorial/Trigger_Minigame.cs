using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger_Minigame : MonoBehaviour
{
    public void TriggerMinigame()
    {
        gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);

        gameObject.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
    }
}
