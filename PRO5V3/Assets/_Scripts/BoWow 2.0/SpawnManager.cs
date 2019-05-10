using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] letters;
    float radius = 3f;

    void Start()
    {
        List<GameObject> letterList = new List<GameObject>();

        Debug.Log(letterList);

        for (int i = 1; i < 10; i++)
        {
            //int randomIndex = Random.Range(0, letterList.Count);
            //Debug.Log("INDEX: " + randomIndex);
            Debug.Log("LOOP: " + i);
            Debug.Log("COUNT: " + letterList.Count);
            float angle = i * Mathf.PI * 2f / 10;
            Vector3 newPos = new Vector3(Mathf.Cos(angle) * radius, 36.0f, Mathf.Sin(angle) * radius);
            GameObject instance = Instantiate(letterList[i], newPos, Quaternion.identity);
            instance.name = instance.name.Replace("(Clone)", "").Trim();
            //instance.gameObject.GetComponent<TargetController>().tMan = this;
            //instance.gameObject.GetComponent<TargetController>().lMan = launcherManager;
            //instance.gameObject.GetComponent<TargetController>().lookPoint = lookPoint;
            Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
            letterList.RemoveAt(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
