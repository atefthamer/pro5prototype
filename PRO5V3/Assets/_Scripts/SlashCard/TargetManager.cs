using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targets;
    float radius = 3f;

    public GameObject[] completeTargets;

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
    public bool targetDestroyed;
    //[HideInInspector]
    //public bool secondHit;
    [HideInInspector]
    public int score;

    [SerializeField]
    Transform lookPoint = null;

    public float speed = 1.0f;

    private float speechTimer = 0.0f;
    private float lookTimer = 0.0f;

    public LauncherManager launcherManager;
    public SwordController sword;
    public ShieldController shield;
    public SlashcardSFX SFX;
    public GameObject spawnPoint;

    private float xValue;
    private float yValue;
    private float zValue;

    private void Start()
    {
        correct = true;
        incorrect = true;
        score = 0;

        xValue = spawnPoint.transform.position.x;
        yValue = spawnPoint.transform.position.y;
        zValue = spawnPoint.transform.position.z;

        List<GameObject> spawnList = new List<GameObject>(targets);

        // CODE FOR CARDS IN CIRCLE

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
            instance.gameObject.GetComponent<TargetController>().sCon = shield;
            instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
            Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
            spawnList.RemoveAt(randomIndex);
        }

        // CODE FOR CARDS IN ROWS

        //for (int i = 0; i < 5; i++)
        //{
        //    int randomIndex = Random.Range(0, spawnList.Count);
        //    Debug.Log("INDEX: " + randomIndex);
        //    Debug.Log("LOOP: " + i);
        //    Debug.Log("COUNT: " + spawnList.Count);
        //    GameObject instance = Instantiate(spawnList[randomIndex], new Vector3(xValue, yValue, zValue), Quaternion.identity);
        //    zValue += 1.5f;
        //    instance.name = instance.name.Replace("(Clone)", "").Trim();
        //    instance.gameObject.GetComponent<TargetController>().tMan = this;
        //    instance.gameObject.GetComponent<TargetController>().lMan = launcherManager;
        //    instance.gameObject.GetComponent<TargetController>().sCon = shield;
        //    //instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
        //    Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
        //    spawnList.RemoveAt(randomIndex);

        //    if (i == 4)
        //    {
        //        yValue += 2.0f;
        //        zValue = spawnPoint.transform.position.z;

        //        for (int j = 0; j < 5; j++)
        //        {
        //            randomIndex = Random.Range(0, spawnList.Count);
        //            Debug.Log("INDEX: " + randomIndex);
        //            Debug.Log("LOOP: " + j);
        //            Debug.Log("COUNT: " + spawnList.Count);
        //            instance = Instantiate(spawnList[randomIndex], new Vector3(xValue, yValue, zValue), Quaternion.identity);
        //            zValue += 1.5f;
        //            instance.name = instance.name.Replace("(Clone)", "").Trim();
        //            instance.gameObject.GetComponent<TargetController>().tMan = this;
        //            instance.gameObject.GetComponent<TargetController>().lMan = launcherManager;
        //            instance.gameObject.GetComponent<TargetController>().sCon = shield;
        //            //instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
        //            Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
        //            spawnList.RemoveAt(randomIndex);
        //        }
        //    }
        //}
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

                //speechTimer += Time.deltaTime;
                targetHittable = true;
                sword.ChargeSword();

                float shot = speed * Time.deltaTime;
                firstTarget.transform.position = Vector3.MoveTowards(firstTarget.transform.position, lookPoint.transform.position, shot);
                secondTarget.transform.position = Vector3.MoveTowards(secondTarget.transform.position, lookPoint.transform.position, shot);

                if (Vector3.Distance(firstTarget.transform.position, lookPoint.transform.position) < 0.1f && (Vector3.Distance(secondTarget.transform.position, lookPoint.transform.position) < 0.1f))
                {
                    GameObject obj = null;
                    firstTarget.gameObject.SetActive(false);
                    secondTarget.gameObject.SetActive(false);

                    if (firstTarget.name == "Card")
                    {
                        obj = Instantiate(completeTargets[0], lookPoint.transform.position, Quaternion.identity);
                        obj.name = obj.name.Replace("(Clone)", "").Trim();
                        obj.transform.Rotate(0, 180, 0);
                        obj.gameObject.GetComponent<CompleteTargetController>().tMan = this;
                        obj.gameObject.GetComponent<CompleteTargetController>().lMan = launcherManager;
                        Destroy(firstTarget);
                        Destroy(secondTarget);
                        targetsHit = false;
                    }
                    else if (firstTarget.name == "Card2")
                    {
                        obj = Instantiate(completeTargets[1], lookPoint.transform.position, Quaternion.identity);
                        obj.name = obj.name.Replace("(Clone)", "").Trim();
                        obj.transform.Rotate(0, 180, 0);
                        obj.gameObject.GetComponent<CompleteTargetController>().tMan = this;
                        obj.gameObject.GetComponent<CompleteTargetController>().lMan = launcherManager;
                        Destroy(firstTarget);
                        Destroy(secondTarget);
                        targetsHit = false;
                    }
                    else if (firstTarget.name == "Card3")
                    {
                        obj = Instantiate(completeTargets[2], lookPoint.transform.position, Quaternion.identity);
                        obj.name = obj.name.Replace("(Clone)", "").Trim();
                        obj.transform.Rotate(0, 180, 0);
                        obj.gameObject.GetComponent<CompleteTargetController>().tMan = this;
                        obj.gameObject.GetComponent<CompleteTargetController>().lMan = launcherManager;
                        Destroy(firstTarget);
                        Destroy(secondTarget);
                        targetsHit = false;
                    }
                    else if (firstTarget.name == "Card4")
                    {
                        obj = Instantiate(completeTargets[3], lookPoint.transform.position, Quaternion.identity);
                        obj.name = obj.name.Replace("(Clone)", "").Trim();
                        obj.transform.Rotate(0, 180, 0);
                        obj.gameObject.GetComponent<CompleteTargetController>().tMan = this;
                        obj.gameObject.GetComponent<CompleteTargetController>().lMan = launcherManager;
                        Destroy(firstTarget);
                        Destroy(secondTarget);
                        targetsHit = false;
                    }
                    else if (firstTarget.name == "Card5")
                    {
                        obj = Instantiate(completeTargets[4], lookPoint.transform.position, Quaternion.identity);
                        obj.name = obj.name.Replace("(Clone)", "").Trim();
                        obj.transform.Rotate(0, 180, 0);
                        obj.gameObject.GetComponent<CompleteTargetController>().tMan = this;
                        obj.gameObject.GetComponent<CompleteTargetController>().lMan = launcherManager;
                        Destroy(firstTarget);
                        Destroy(secondTarget);
                        targetsHit = false;
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
            }
        }

        if (lookTimer >= 2.0f)
        {
            launcherManager.NextLauncher();
            firstTarget.gameObject.transform.Rotate(0, 180, 0);
            //firstTarget.GetComponent<Shake>().ObjectShake();
            secondTarget.gameObject.transform.Rotate(0, 180, 0);
            //secondTarget.GetComponent<Shake>().ObjectShake();
            incorrect = true;
            firstTarget = null;
            secondTarget = null;
            targetsHit = false;
            lookTimer = 0.0f;
        }

        if (targetDestroyed == true)
        {
            score++;
            sword.UnchargeSword();
            correct = true;
            speechTimer = 0.0f;
            targetHittable = false;
            firstTarget = null;
            secondTarget = null;
            targetsHit = false;
            targetDestroyed = false;
        }
    }
}
