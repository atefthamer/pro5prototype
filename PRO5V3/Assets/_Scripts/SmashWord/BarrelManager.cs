using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelManager : MonoBehaviour
{
    public GameObject[] barrelGroup1;
    public GameObject[] barrelGroup2;
    public GameObject[] barrelGroup3;

    private List<GameObject> destroyList = new List<GameObject>();

    private float firstTimer = 0.0f;
    private float secondTimer = 0.0f;

    private float xValue;
    private float yValue;
    private float zValue;

    public AudioClip firstQuestion;
    public AudioClip secondQuestion;
    public AudioClip thirdQuestion;

    private bool playSecondQuestion;
    private bool playThirdQuestion;

    [HideInInspector]
    public bool firstGroupHit = false;
    [HideInInspector]
    public bool secondGroupHit = false;
    [HideInInspector]
    public bool thirdGroupHit = false;

    void Start()
    {
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(firstQuestion);

        playSecondQuestion = true;
        playThirdQuestion = true;

        xValue = this.gameObject.transform.position.x;
        yValue = this.gameObject.transform.position.y;
        zValue = this.gameObject.transform.position.z;

        for (int i = 0; i < 3; i++)
        {
            GameObject obj = Instantiate(barrelGroup1[i], new Vector3(xValue, yValue, zValue), Quaternion.identity);
            xValue -= 0.8f;
            obj.name = obj.name.Replace("(Clone)", "").Trim();
            obj.gameObject.GetComponent<BarrelController>().bMan = this;
            obj.transform.Rotate(-90.0f, 0.0f, 180.0f);
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
            foreach (GameObject go in destroyList)
            {
                Destroy(go);
                //destroyList.Clear();
            }

            firstTimer += Time.deltaTime;

            if (firstTimer >= 1.0f)
            {
                if (playSecondQuestion == true)
                {
                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(secondQuestion);
                    playSecondQuestion = false;
                }

                for (int j = 0; j < 3; j++)
                {
                    GameObject obj = Instantiate(barrelGroup2[j], new Vector3(xValue, yValue, zValue), Quaternion.identity);
                    xValue -= 0.8f;
                    obj.name = obj.name.Replace("(Clone)", "").Trim();
                    obj.gameObject.GetComponent<BarrelController>().bMan = this;
                    obj.transform.Rotate(-90.0f, 0.0f, 180.0f);
                    destroyList.Add(obj);

                    if (j == 2)
                    {
                        xValue = this.gameObject.transform.position.x;
                        firstGroupHit = false;
                    }
                }
            }
        }

        if (secondGroupHit == true)
        {
            foreach (GameObject go in destroyList)
            {
                Destroy(go);
                //destroyList.Clear();
            }

            secondTimer += Time.deltaTime;

            if (secondTimer >= 1.0f)
            {
                if (playThirdQuestion == true)
                {
                    this.gameObject.GetComponent<AudioSource>().PlayOneShot(thirdQuestion);
                    playThirdQuestion = false;
                }

                for (int k = 0; k < 3; k++)
                {
                    GameObject obj = Instantiate(barrelGroup3[k], new Vector3(xValue, yValue, zValue), Quaternion.identity);
                    xValue -= 0.8f;
                    obj.name = obj.name.Replace("(Clone)", "").Trim();
                    obj.gameObject.GetComponent<BarrelController>().bMan = this;
                    obj.transform.Rotate(-90.0f, 0.0f, 180.0f);
                    destroyList.Add(obj);

                    if (k == 2)
                    {
                        xValue = this.gameObject.transform.position.x;
                        secondGroupHit = false;
                    }
                }
            }
        }

        if (thirdGroupHit == true)
        {
            foreach (GameObject go in destroyList)
            {
                Destroy(go);
                //destroyList.Clear();
            }
        }
    }
}
