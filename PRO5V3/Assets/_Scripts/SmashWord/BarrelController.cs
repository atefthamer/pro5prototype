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
            this.gameObject.GetComponent<Animator>().Play("BarrelAnimation");
            if (this.gameObject.name == "SmashWordBarrel")
            {
                //StartCoroutine(bMan.PlayQuestion1(6.17f, 1));
                bMan.PlaySound(1);
                bMan.RemoveBarrels();
                bMan.firstGroupHit = true;
            }
            else if (this.gameObject.name == "SmashWordBarrel 2")
            {
                //StartCoroutine(bMan.PlayQuestion1(4.6f, 3));
                bMan.PlaySound(3);
                bMan.RemoveBarrels();
                bMan.firstGroupHit = true;
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
            //SpawnParticle();
            if (this.gameObject.name == "SmashWordBarrel 3")
            {
                //StartCoroutine(bMan.QuestionNumerator(4, 6.650f));
                bMan.PlaySound(4);
                bMan.RemoveBarrels();
                bMan.secondGroupHit = true;
            }
            else if (this.gameObject.name == "SmashWordBarrel 5")
            {
                //StartCoroutine(bMan.QuestionNumerator(6, 6.515f));
                bMan.PlaySound(6);
                bMan.RemoveBarrels();
                bMan.secondGroupHit = true;
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
            //SpawnParticle();
            if (this.gameObject.name == "SmashWordBarrel 6")
            {
                //StartCoroutine(bMan.PlayQuestion3(8, 18.613f));
                bMan.PlaySound(8);
                bMan.RemoveBarrels();
                bMan.thirdGroupHit = true;
            }
            else if (this.gameObject.name == "SmashWordBarrel 8")
            {
                //StartCoroutine(bMan.PlayQuestion3(10, 16.485f));
                bMan.PlaySound(10);
                bMan.RemoveBarrels();
                bMan.thirdGroupHit = true;
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