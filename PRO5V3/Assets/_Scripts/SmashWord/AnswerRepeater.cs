using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerRepeater : MonoBehaviour
{
    public AudioClip answer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("COLLISION DETECTED");
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(answer);
        }
    }
}
