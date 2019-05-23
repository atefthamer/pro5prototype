using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [HideInInspector]
    public RabController rcontrol;
    public BarrelManager bMan;
    public AudioClip answer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel" || 
            other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 2")
        {
            Debug.Log("FIRST BARREL GROUP HIT");
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(answer);
            bMan.firstGroupHit = true;
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 1")
        {
            StartCoroutine(rcontrol.RabbitTalkSequence1());
        }

        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 3" ||
            other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 5")
        {
            Debug.Log("SECOND BARREL GROUP HIT");
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(answer);
            bMan.secondGroupHit = true;
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 4")
        {
            StartCoroutine(rcontrol.RabbitTalkSequence2());
        }

        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 6" ||
        other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 8")
        {
            Debug.Log("THIRD BARREL GROUP HIT");
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(answer);
            bMan.thirdGroupHit = true;
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 7")
        {
            StartCoroutine(rcontrol.RabbitTalkSequence3());
        }
    }
}