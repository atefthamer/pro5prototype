using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabControllerZep : MonoBehaviour
{
    public List<AudioClip> rabbitClips = new List<AudioClip>();
    private GameObject islandTracker;
    private bool bol = false;

    void Start()
    {
        islandTracker = GameObject.FindGameObjectWithTag("Tracker");

        if (islandTracker.GetComponent<IslandTracker>().zepTutDone == false)
        {
            StartCoroutine(RabbitTalkSequence());
        }
    }

    private void Update()
    {
        if (StartEngine.EngineRunning == true && islandTracker.GetComponent<IslandTracker>().zepTutDone2 == false && bol == false)
        {
            StartCoroutine(RabbitTalkSequence2());
            bol = true;
        }
    }

    public IEnumerator RabbitTalkSequence()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[0]);
        yield return new WaitForSeconds(8.392f);
        islandTracker.GetComponent<IslandTracker>().zepTutDone = true;
    }

    public IEnumerator RabbitTalkSequence2()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[1]);
        yield return new WaitForSeconds(20.942f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[2]);
        islandTracker.GetComponent<IslandTracker>().zepTutDone2 = true;
    }
}