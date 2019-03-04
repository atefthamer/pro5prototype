using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public ReturnBall ball;
    public GoalMinigame nextGoal;
    public PickCategory categories;
    public SFXTriggers sfx;

    private void FixedUpdate()
    {
        nextGoal.time -= Time.deltaTime;

        if (nextGoal.time <= 0)
        {
            GameFinished();
            categories.ShowCategories();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            //Debug.Log("Goal!");

            if (nextGoal.time <= 0)
            {
                Debug.Log("No Points");
            }
            else if (nextGoal.time >= 0)
            {
                sfx.GoalSound();
                nextGoal.score++;
                nextGoal.NextGoal();
                ball.RespawnBall();
            }
        }
    }

    void GameFinished()
    {
        nextGoal.time = 0;
        nextGoal.gameFinished();
    }
}
