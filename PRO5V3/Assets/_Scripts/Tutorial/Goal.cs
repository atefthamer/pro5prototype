using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ReturnBall ball;
    public Tutorial_Minigame nextTarget;
    public Trigger_Minigame trigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && nextTarget.startMinigame == false)
        {
            ball.RespawnBall();
            nextTarget.NextTarget();
            nextTarget.startMinigame = true;
            trigger.TriggerMinigame();
        }
        else if (other.gameObject.CompareTag("Interactable") && nextTarget.startMinigame == true)
        {
            ball.RespawnBall();
            nextTarget.NextTarget();
            nextTarget.score++;
        }
    }
}
