using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountdown : MonoBehaviour
{
    public GameObject targets;
    public Trigger_Minigame trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            trigger.TriggerMinigame();
            targets.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
