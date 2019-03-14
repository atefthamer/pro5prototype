using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBall : MonoBehaviour
{
    public float timer = 3.0f;
    private bool inside;
    public ReturnBall ball;

    private void Update()
    {
        if (inside == false)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0.0f)
        {
            //Debug.Log("Time's up");
            ball.RespawnBall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            //Debug.Log("Inside");
            inside = true;
            timer = 3.0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            //Debug.Log("Outside");
            inside = false;
        }
    }
}
