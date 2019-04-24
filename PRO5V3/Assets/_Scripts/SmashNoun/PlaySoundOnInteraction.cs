using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnInteraction : MonoBehaviour
{

    public AudioSource audioData;
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            audioData.Play(0);
        }
    }
}