using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetManager : MonoBehaviour
{
    public GameObject[] targets;
    float radius = 5f;

    [HideInInspector]
    public GameObject firstTarget = null;
    [HideInInspector]
    public GameObject secondTarget = null;
    [HideInInspector]
    public bool targetsHit = false;
    [HideInInspector]
    public bool correct;

    public GameObject player;
    public float speed = 1.0f;

    public SlashcardSFX SFX;

    private int[] randomNumber;

    private void Start()
    {
        correct = true;

        List<GameObject> spawnList = new List<GameObject>(targets);

        randomNumber = new int[spawnList.Count];

        for (int i = 0; i < spawnList.Count; i++)
        {
            int randomIndex = Random.Range(0, spawnList.Count);

            while (randomNumber.Contains(randomIndex))
            {
                randomIndex = Random.Range(0, spawnList.Count);
            }

            if (spawnList[randomIndex] != null)
            {
                // TODO: Fix spawning issue
                float angle = i * Mathf.PI * 2f / spawnList.Count;
                Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 1f, Mathf.Sin(angle) * radius);
                GameObject instance = Instantiate(spawnList[randomIndex], newPos, Quaternion.identity);
                instance.name = instance.name.Replace("(Clone)", "").Trim();
                instance.gameObject.GetComponent<TargetController>().tMan = this;
                Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
            }
            else
            {
                return;
            }
        }
    }

    void Update()
    {
        if (targetsHit == true)
        {
            if (firstTarget.name == secondTarget.name && firstTarget != null && secondTarget != null)
            {
                firstTarget.transform.GetChild(0).gameObject.SetActive(false);
                if (correct == true)
                {
                    SFX.Correct();
                    correct = false;
                }
                float shot = speed * Time.deltaTime;
                firstTarget.transform.position = Vector3.MoveTowards(firstTarget.transform.position, player.transform.position, shot);
                secondTarget.transform.position = Vector3.MoveTowards(secondTarget.transform.position, player.transform.position, shot);

                if (Vector3.Distance(firstTarget.transform.position, player.transform.position) < 1.0f && (Vector3.Distance(secondTarget.transform.position, player.transform.position) < 1.0f))
                {
                    Debug.Log("Destination reached");
                    correct = true;
                    targetsHit = false;
                }
            }
            else if (firstTarget.name != secondTarget.name & firstTarget != null && secondTarget != null)
            {
                SFX.Incorrect();
                firstTarget.transform.GetChild(0).gameObject.SetActive(false);
                targetsHit = false;
                firstTarget = null;
                secondTarget = null;
            }
        }
    }
}
