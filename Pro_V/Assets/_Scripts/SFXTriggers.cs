using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXTriggers : MonoBehaviour
{
    AudioSource audioData;
    public float volume = 1.0f;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.volume = volume;
    }

    public void GoalSound()
    {
        audioData.Play(0);
    }
}
