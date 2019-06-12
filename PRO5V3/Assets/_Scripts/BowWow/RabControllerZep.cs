﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabControllerZep : MonoBehaviour
{
    public List<AudioClip> rabbitClips = new List<AudioClip>();

    void Start()
    {
        StartCoroutine(RabbitTalkSequence());
    }

    public IEnumerator RabbitTalkSequence()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[0]);
        yield return new WaitForSeconds(8.392f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[1]);
        yield return new WaitForSeconds(20.942f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[2]);
    }
}