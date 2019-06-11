using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [HideInInspector]
    public RabController rcontrol;
    public BarrelManager bMan;
    public AudioClip answer;
    public GameObject particle;

    private void Update()
    {
        if (bMan.barrelHit == true)
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel" || 
            other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 2")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("FIRST BARREL GROUP HIT");
            bMan.RemoveBarrels();
            SpawnParticle();
            if (this.gameObject.name == "SmashWordBarrel")
            {
                bMan.PlayQuestion(1, 6.170f, bMan.firstGroupHit);
            }
            else
            {
                bMan.PlayQuestion(3, 4.6f, bMan.firstGroupHit);
            }
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 1")
        {
            bMan.barrelHit = true;
            StartCoroutine(rcontrol.RabbitTalkSequence1());
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("FIRST BARREL GROUP HIT");
        }

        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 3" ||
            other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 5")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("SECOND BARREL GROUP HIT");
            bMan.RemoveBarrels();
            SpawnParticle();
            if (this.gameObject.name == "SmashWordBarrel 3")
            {
                StartCoroutine(bMan.QuestionNumerator(4, 6.650f));
            }
            else
            {
                StartCoroutine(bMan.QuestionNumerator(6, 6.515f));
            }
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 4")
        {
            bMan.barrelHit = true;
            StartCoroutine(rcontrol.RabbitTalkSequence2());
        }

        if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 6" ||
        other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 8")
        {
            this.gameObject.GetComponent<MeshCollider>().enabled = false;
            Debug.Log("THIRD BARREL GROUP HIT");
            bMan.RemoveBarrels();
            SpawnParticle();
            if (this.gameObject.name == "SmashWordBarrel 6")
            {
                bMan.PlayQuestion(8, 18.613f, bMan.thirdGroupHit);
            }
            else
            {
                bMan.PlayQuestion(10, 16.485f, bMan.thirdGroupHit);
            }
        }
        else if (other.gameObject.CompareTag("Hammer") && this.gameObject.name == "SmashWordBarrel 7")
        {
            bMan.barrelHit = true;
            StartCoroutine(rcontrol.RabbitTalkSequence3());
        }

    }
    private void SpawnParticle()
    {
        GameObject smoke = Instantiate(particle, this.transform.position, Quaternion.identity);
        Destroy(smoke, 5.0f);
    }
}