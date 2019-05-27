using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [HideInInspector]
    public Transform lookPoint = null;
    [HideInInspector]
    public LetterManager lMan;
    [HideInInspector]
    public GameObject hitParticle;

    void Update()
    {
        transform.LookAt(lookPoint);
        // Makes words rotate around lookPoint
        transform.RotateAround(lookPoint.transform.position, new Vector3(0, 0.1f, 0), 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("projectile") && this.gameObject.name == "Dus" && lMan.sentence.text == "Mijn vriend en ik vervelen ons, ... gaan wij buitenspelen" ||
            other.gameObject.CompareTag("projectile") && this.gameObject.name == "Maar" && lMan.sentence.text == "Ik moet naar bed, ... ik ben nog niet moe" ||
            other.gameObject.CompareTag("projectile") && this.gameObject.name == "Want" && lMan.sentence.text == "Ik moet na school mijn huiswerk maken, ... ik wil geen straf" ||
            other.gameObject.CompareTag("projectile") && this.gameObject.name == "En" && lMan.sentence.text == "Als ik groot ben wil ik trouwen, ... ik wil gaan reizen" ||
            other.gameObject.CompareTag("projectile") && this.gameObject.name == "Of" && lMan.sentence.text == "Ik kom straks naar buiten, ... na het avond eten")
        {
            if (lMan.score < 5)
            {               
                Explode(other.gameObject);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                lMan.sentenceList.RemoveAt(lMan.randomSentence);
                lMan.score++;
                lMan.NextSentence();
            }
        }
        else
        {
            lMan.IncorrectSound();
        }
    }

    private void Explode(GameObject arrow)
    {
        lMan.CorrectSound();
        GameObject explode = Instantiate(hitParticle, arrow.transform.position, Quaternion.identity);
        explode.GetComponent<ParticleController>().targetCamera = (Transform)lookPoint;
        hitParticle.GetComponent<ParticleSystem>().Play();
        Destroy(explode, 2.0f);
    }
}
