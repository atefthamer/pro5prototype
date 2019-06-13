using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LetterManager : MonoBehaviour
{
    public GameObject[] letters;

    float radius = 4f;

    public List<string> sentenceList = new List<string>();

    [HideInInspector]
    public int score;
    [HideInInspector]
    public int randomSentence;

    public TextMeshPro sentence;
    public TextMeshPro scoreText;
    public GameObject ladder;

    public AudioClip correct;
    public AudioClip incorrect;

    [SerializeField]
    Transform lookPoint = null;
    public GameObject particle;

    public GameObject leftHand;
    public GameObject rightHand;

    void Start()
    {
        score = 0;

        List<GameObject> spawnList = new List<GameObject>(letters);

        for (int i = 0; i < 5; i++)
        {
            int randomIndex = Random.Range(0, spawnList.Count);
            Debug.Log("INDEX: " + randomIndex);
            Debug.Log("LOOP: " + i);
            float angle = i * Mathf.PI * 2f / 5;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 1.5f, Mathf.Sin(angle) * radius);
            GameObject instance = Instantiate(spawnList[randomIndex], newPos, Quaternion.identity);
            instance.name = instance.name.Replace("(Clone)", "").Trim();
            instance.gameObject.GetComponent<LetterController>().lMan = this;
            instance.gameObject.GetComponent<LetterController>().lookPoint = lookPoint;
            instance.gameObject.GetComponent<LetterController>().hitParticle = particle;
            Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
            spawnList.RemoveAt(randomIndex);
        }

        randomSentence = Random.Range(0, sentenceList.Count);
        sentence.text = sentenceList[randomSentence];
        Debug.Log("CURRENT SENTENCE: " + sentenceList[randomSentence]);
        //sentenceList.RemoveAt(randomSentence);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;

        if (score >= 5)
        {
            sentence.text = "Goed gedaan! Klim de ladder op om terug te gaan naar de zeppelin";
            ladder.gameObject.SetActive(true);
            leftHand.gameObject.GetComponent<SphereCollider>().enabled = true;
            rightHand.gameObject.GetComponent<SphereCollider>().enabled = true;
            //leftHand.gameObject.AddComponent<Rigidbody>();
            //rightHand.gameObject.AddComponent<Rigidbody>();
            score--;
        }
    }

    public void NextSentence()
    {
        randomSentence = Random.Range(0, sentenceList.Count);
        sentence.text = sentenceList[randomSentence];
        Debug.Log("CURRENT SENTENCE: " + sentenceList[randomSentence]);
        //sentenceList.RemoveAt(randomSentence);
    }

    public void CorrectSound()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(correct);
    }

    public void IncorrectSound()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(incorrect);
    }
}
