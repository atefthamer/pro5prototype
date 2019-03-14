using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ReturnBall ball;
    public Tutorial_Minigame nextTarget;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            ball.RespawnBall();
            nextTarget.NextTarget();
            nextTarget.score++;
        }
    }
}
