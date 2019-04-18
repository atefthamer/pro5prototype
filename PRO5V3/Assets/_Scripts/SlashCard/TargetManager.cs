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
    public bool incorrect = false;
    [HideInInspector]
    public bool targetsHit = false;

    public GameObject player;
    public float speed = 1.0f;

    private void Start()
    {
        List<GameObject> spawnList = new List<GameObject>(targets);

        while (spawnList.Count > 0)
        {
            for (int i = 0; i < spawnList.Count; i++)
            {
                int randomIndex = Random.Range(0, spawnList.Count);

                if (spawnList[randomIndex] != null)
                {
                    // TODO: Fix spawning issue
                    float angle = i * Mathf.PI * 2f / 20;
                    Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 1f, Mathf.Sin(angle) * radius);
                    GameObject instance = Instantiate(spawnList[randomIndex], newPos, Quaternion.identity);
                    instance.gameObject.GetComponent<TargetController>().tMan = this;
                    Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
                }
                else
                {
                    return;
                }
                spawnList.RemoveAt(randomIndex);
            }
        }
    }

    void Update()
    {
        if (targetsHit == true)
        {
            if (firstTarget.name == secondTarget.name)
            {
                float shot = speed * Time.deltaTime;
                firstTarget.transform.position = Vector3.MoveTowards(firstTarget.transform.position, player.transform.position, shot);
                secondTarget.transform.position = Vector3.MoveTowards(secondTarget.transform.position, player.transform.position, shot);

                if (Vector3.Distance(firstTarget.transform.position, player.transform.position) < 1.0f && (Vector3.Distance(secondTarget.transform.position, player.transform.position) < 1.0f))
                {
                    // TODO: Something
                }

            }
            else if (firstTarget.name != secondTarget.name)
            {
                incorrect = true;
                targetsHit = false;
                firstTarget = null;
                secondTarget = null;
            }
        }
    }
}
