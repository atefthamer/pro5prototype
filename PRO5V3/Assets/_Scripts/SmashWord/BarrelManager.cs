using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour
{
    public RabController rabcontrol;

    public GameObject[] barrelGroup1;
    public GameObject[] barrelGroup2;
    public GameObject[] barrelGroup3;

    public GameObject ladder;
    public GameObject particle;

    private List<GameObject> destroyList = new List<GameObject>();

    private float xValue;
    private float yValue;
    private float zValue;

    [HideInInspector]
    public bool barrelHit;

    public List<AudioClip> foxQuestions = new List<AudioClip>();

    [HideInInspector]
    public bool firstGroupHit = false;
    [HideInInspector]
    public bool secondGroupHit = false;
    [HideInInspector]
    public bool thirdGroupHit = false;

    void Start()
    {
        barrelHit = false;

        xValue = this.gameObject.transform.position.x;
        yValue = this.gameObject.transform.position.y;
        zValue = this.gameObject.transform.position.z;

        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(barrelGroup1[i], new Vector3(xValue, yValue, zValue), Quaternion.identity);
            xValue -= 1.2f;
            obj.name = obj.name.Replace("(Clone)", "").Trim();
            obj.gameObject.GetComponent<BarrelController>().bMan = this;
            obj.gameObject.GetComponent<BarrelController>().rcontrol = rabcontrol;
            destroyList.Add(obj);

            if (i == 2)
            {
                xValue = this.gameObject.transform.position.x;
            }
        }
    }

    void Update()
    {
        if (firstGroupHit == true)
        {
            for (int j = 0; j < 3; j++)
            {
                GameObject obj = Instantiate(barrelGroup2[j], new Vector3(xValue, yValue, zValue), Quaternion.identity);
                xValue -= 1.2f;
                obj.name = obj.name.Replace("(Clone)", "").Trim();
                obj.gameObject.GetComponent<BarrelController>().bMan = this;
                obj.gameObject.GetComponent<BarrelController>().rcontrol = rabcontrol;
                destroyList.Add(obj);

                if (j == 2)
                {
                    xValue = this.gameObject.transform.position.x;
                    firstGroupHit = false;
                }
            }
        }

        if (secondGroupHit == true)
        {
            for (int k = 0; k < 3; k++)
            {
                GameObject obj = Instantiate(barrelGroup3[k], new Vector3(xValue, yValue, zValue), Quaternion.identity);
                xValue -= 1.2f;
                obj.name = obj.name.Replace("(Clone)", "").Trim();
                obj.gameObject.GetComponent<BarrelController>().bMan = this;
                obj.gameObject.GetComponent<BarrelController>().rcontrol = rabcontrol;
                destroyList.Add(obj);

                if (k == 2)
                {
                    xValue = this.gameObject.transform.position.x;
                    secondGroupHit = false;
                }         
            }
        }

        if (thirdGroupHit == true)
        {
            ladder.gameObject.SetActive(true);
        }
    }

    public void RemoveBarrels()
    {
        foreach (GameObject go in destroyList)
        {
            Destroy(go);
        }
    }

    public IEnumerator PlayQuestion(int index, float waitTime, bool trigger)
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(foxQuestions[index]);
        yield return new WaitForSeconds(waitTime);
        trigger = true;
    }

    public IEnumerator PlayQuestionWithoutBool(int index, float waitTime)
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(foxQuestions[index]);
        yield return new WaitForSeconds(waitTime);
    }

    public IEnumerator QuestionNumerator(int index, float waitTime)
    {
        StartCoroutine(PlayQuestionWithoutBool(index, waitTime));
        yield return new WaitForSeconds(7.0f);
        PlayQuestion(7, 1.868f, secondGroupHit);
    }
}