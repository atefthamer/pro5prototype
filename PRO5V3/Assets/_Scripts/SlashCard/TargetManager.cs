﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targets;
    float radius = 3f;

    [HideInInspector]
    public GameObject firstTarget = null;
    [HideInInspector]
    public GameObject secondTarget = null;
    [HideInInspector]
    public bool targetsHit = false;
    [HideInInspector]
    public bool correct;
    [HideInInspector]
    public bool incorrect;
    [HideInInspector]
    public bool targetHittable = false;
    [HideInInspector]
    public bool firstHit;
    [HideInInspector]
    public bool secondHit;

    [SerializeField]
    Transform lookPoint = null;

    public float speed = 1.0f;

    private float speechTimer = 0.0f;
    private float lookTimer = 0.0f;

    public LauncherManager launcherManager;
    public SwordController sword;
    public SlashcardSFX SFX;

    private void Start()
    {
        correct = true;
        incorrect = true;

        List<GameObject> spawnList = new List<GameObject>(targets);

        for (int i = 0; i < 10; i++)
        {
            int randomIndex = Random.Range(0, spawnList.Count);
            Debug.Log("INDEX: " + randomIndex);
            Debug.Log("LOOP: " + i);
            Debug.Log("COUNT: " + spawnList.Count);
            float angle = i * Mathf.PI * 2f / 10;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 1.0f, Mathf.Sin(angle) * radius);
            GameObject instance = Instantiate(spawnList[randomIndex], newPos, Quaternion.identity);
            instance.name = instance.name.Replace("(Clone)", "").Trim();
            instance.gameObject.GetComponent<TargetController>().tMan = this;
            instance.gameObject.GetComponent<TargetController>().lMan = launcherManager;
            instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
            Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
            spawnList.RemoveAt(randomIndex);
        }
    }

    void Update()
    {
        if (targetsHit == true)
        {
            if (firstTarget.name == secondTarget.name)
            {
                if (correct == true)
                {
                    SFX.Correct();
                    correct = false;
                }

                speechTimer += Time.deltaTime;

                if (speechTimer >= 3.0f)
                {
                    targetHittable = true;
                    sword.ChargeSword();

                    float shot = speed * Time.deltaTime;
                    firstTarget.transform.position = Vector3.MoveTowards(firstTarget.transform.position, lookPoint.transform.position, shot);
                    secondTarget.transform.position = Vector3.MoveTowards(secondTarget.transform.position, lookPoint.transform.position, shot);

                    if (Vector3.Distance(firstTarget.transform.position, lookPoint.transform.position) < 1.0f && (Vector3.Distance(secondTarget.transform.position, lookPoint.transform.position) < 1.0f))
                    {
                        Debug.Log("Destination reached");
                    }
                }
            }
            else if (firstTarget.name != secondTarget.name)
            {
                if (incorrect == true)
                {
                    SFX.Incorrect();
                    incorrect = false;
                }

                lookTimer += Time.deltaTime;

                if (lookTimer >= 3.0f)
                {
                    firstTarget.gameObject.transform.Rotate(0, 180, 0);
                    //firstTarget.GetComponent<Shake>().ObjectShake();
                    secondTarget.gameObject.transform.Rotate(0, 180, 0);
                    //secondTarget.GetComponent<Shake>().ObjectShake();
                    incorrect = true;
                    lookTimer = 0.0f;
                    firstTarget = null;
                    secondTarget = null;
                    targetsHit = false;
                }
            }
        }

        if (firstHit == true && secondHit == true)
        {
            sword.UnchargeSword();
            correct = true;
            speechTimer = 0.0f;
            targetHittable = false;
            targetsHit = false;
            firstHit = false;
            secondHit = false;
        }
    }
}
