using System.Collections;
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
    public bool incorrect = false;
    [HideInInspector]
    public bool firstHit;
    [HideInInspector]
    public bool secondHit;

    [SerializeField]
    Transform lookPoint = null;

    //public GameObject player;
    public float speed = 1.0f;

    private float speechTimer = 0.0f;

    //private AudioSource audioSource;

    public LauncherManager launcherManager;
    public SwordController sword;
    public SlashcardSFX SFX;

    //private int[] randomNumber;

    private void Start()
    {
        if (targets != null)
        {
            List<GameObject> spawnList = new List<GameObject>(targets);

            while (spawnList.Count > 0)
            {
                int randomIndex = Random.Range(0, spawnList.Count);
                Vector3 center = transform.position;

                for (int i = 0; i < spawnList.Count; i++)
                {
                    Vector3 pos = RandomCircle(center, 3.0f);
                    //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
                    GameObject instance = Instantiate(spawnList[randomIndex], pos, Quaternion.identity);
                    instance.name = instance.name.Replace("(Clone)", "").Trim();
                    instance.gameObject.GetComponent<TargetController>().tMan = this;
                    instance.gameObject.GetComponent<TargetController>().lMan = launcherManager;
                    instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
                    Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
                    spawnList.RemoveAt(randomIndex);
                }
            }
        }

        //if (targets != null)
        //{
        //    List<GameObject> spawnList = new List<GameObject>(targets);

        //    while (spawnList.Count > 0)
        //    {
        //        int randomIndex = Random.Range(0, spawnList.Count);

        //        for (int i = 0; i < spawnList.Count; i++)
        //        {
        //            if (spawnList.ElementAt(randomIndex) != null)
        //            {
        //                Debug.Log("ELEMENT NOT NULL");
        //                // TODO: Fix spawning issue
        //                float angle = i * Mathf.PI * 2f / 10;
        //                Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 1.0f, Mathf.Sin(angle) * radius);
        //                GameObject instance = Instantiate(spawnList[randomIndex], newPos, Quaternion.identity);
        //                instance.name = instance.name.Replace("(Clone)", "").Trim();
        //                instance.gameObject.GetComponent<TargetController>().tMan = this;
        //                instance.gameObject.GetComponent<TargetController>().lMan = launcherManager;
        //                instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
        //                Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
        //                spawnList.RemoveAt(randomIndex);
        //            }
        //            else if (spawnList.ElementAt(randomIndex) == null)
        //            {
        //                Debug.Log("ELEMENT IS NULL");
        //                i--;
        //            }
        //        }
        //    }
        //}

        //correct = true;

        //List<GameObject> spawnList = new List<GameObject>(targets);

        //for (int i = 0; i < spawnList.Count; i++)
        //{
        //    int randomIndex = Random.Range(0, spawnList.Count);
        //    Debug.Log(randomIndex);

        //    if (spawnList.ElementAt(randomIndex) != null)
        //    {
        //        Debug.Log("ELEMENT NOT NULL");
        //        // TODO: Fix spawning issue
        //        float angle = i * Mathf.PI * 2f / 10;
        //        Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 1.0f, Mathf.Sin(angle) * radius);
        //        GameObject instance = Instantiate(spawnList[randomIndex], newPos, Quaternion.identity);
        //        instance.name = instance.name.Replace("(Clone)", "").Trim();
        //        instance.gameObject.GetComponent<TargetController>().tMan = this;
        //        instance.gameObject.GetComponent<TargetController>().lMan = launcherManager;
        //        instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
        //        Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
        //        spawnList.RemoveAt(randomIndex);
        //    }
        //    else if (spawnList.ElementAt(randomIndex) == null)
        //    {
        //        Debug.Log("ELEMENT IS NULL");
        //        i--;
        //    }
        //}
    }

    void Update()
    {
        if (targetsHit == true)
        {
            if (firstTarget.name == secondTarget.name && firstTarget != null && secondTarget != null)
            {
                if (correct == true)
                {
                    SFX.Correct();
                    correct = false;
                }

                //audioSource.clip = Microphone.Start("Microphone (VIVE Pro Mutimedia Audio)", false, 3, 44100);
                //firstTarget.transform.GetChild(0).gameObject.SetActive(false);
                speechTimer += Time.deltaTime;

                if (speechTimer >= 3.0f)
                {
                    speechTimer = 3.0f;

                    sword.ChargeSword();

                    float shot = speed * Time.deltaTime;
                    firstTarget.transform.position = Vector3.MoveTowards(firstTarget.transform.position, lookPoint.transform.position, shot);
                    secondTarget.transform.position = Vector3.MoveTowards(secondTarget.transform.position, lookPoint.transform.position, shot);

                    if (Vector3.Distance(firstTarget.transform.position, lookPoint.transform.position) < 1.0f && (Vector3.Distance(secondTarget.transform.position, lookPoint.transform.position) < 1.0f))
                    {
                        Debug.Log("Destination reached");
                        //audioSource.clip = null;
                        correct = true;
                        speechTimer = 0.0f;
                        targetsHit = false;
                    }
                }
                //else
                //{
                //    audioSource.clip = Microphone.Start("Microphone (VIVE Pro Mutimedia Audio)", false, 3, 44100);
                //    return;
                //}
            }
            else if (firstTarget.name != secondTarget.name & firstTarget != null && secondTarget != null)
            {
                SFX.Incorrect();
                //firstTarget.transform.GetChild(0).gameObject.SetActive(false);
                incorrect = true;
                targetsHit = false;
            }
        }

        if (firstHit == true && secondHit == true)
        {
            sword.UnchargeSword();
            firstHit = false;
            secondHit = false;
        }
    }

    Vector3 RandomCircle (Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
