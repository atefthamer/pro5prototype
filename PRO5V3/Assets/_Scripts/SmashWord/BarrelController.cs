using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [HideInInspector]
    public RabController rcontrol;
    public BarrelManager bMan;
    public AudioClip answer;

    private void Update()
    {
        if (bMan.barrelHit == true)
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel" || 
            other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 2")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("FIRST BARREL GROUP HIT");
            bMan.RemoveBarrels();
            if (this.gameObject.name == "Barrel")
            {
                bMan.PlayQuestion(1, 6.170f, bMan.firstGroupHit);
            }
            else
            {
                bMan.PlayQuestion(3, 4.6f, bMan.firstGroupHit);
            }
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 1")
        {
            bMan.barrelHit = true;
            StartCoroutine(rcontrol.RabbitTalkSequence1());
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("FIRST BARREL GROUP HIT");
        }

        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 3" ||
            other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 5")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("SECOND BARREL GROUP HIT");
            bMan.RemoveBarrels();
            if (this.gameObject.name == "Barrel 3")
            {
                StartCoroutine(bMan.QuestionNumerator(4, 6.650f));
            }
            else
            {
                StartCoroutine(bMan.QuestionNumerator(6, 6.515f));
            }
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 4")
        {
            bMan.barrelHit = true;
            StartCoroutine(rcontrol.RabbitTalkSequence2());
        }

        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 6" ||
        other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 8")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("THIRD BARREL GROUP HIT");
            bMan.RemoveBarrels();
            if (this.gameObject.name == "Barrel 6")
            {
                bMan.PlayQuestion(8, 18.613f, bMan.thirdGroupHit);
            }
            else
            {
                bMan.PlayQuestion(10, 16.485f, bMan.thirdGroupHit);
            }
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "Barrel 7")
        {
            bMan.barrelHit = true;
            StartCoroutine(rcontrol.RabbitTalkSequence3());
        }
    }
}