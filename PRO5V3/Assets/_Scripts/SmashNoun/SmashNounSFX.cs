using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmashNounSFX : MonoBehaviour
{
    public AudioSource audio;

    public AudioClip correctSound;
    public AudioClip incorrectSound;
    public AudioClip destroyBarrel;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Correct()
    {
        audio.PlayOneShot(correctSound, 1.0f);
        audio.PlayOneShot(destroyBarrel, 1.0f);
    }

    public void Incorrect()
    {
        audio.PlayOneShot(incorrectSound, 1.0f);
        audio.PlayOneShot(destroyBarrel, 1.0f);
    }

    public void DestroyBarrel()
    {
        audio.PlayOneShot(destroyBarrel, 1.0f);
    }
}
