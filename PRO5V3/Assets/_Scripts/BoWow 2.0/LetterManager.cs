using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterManager : MonoBehaviour
{
    public GameObject[] letters;
    float radius = 5f;

    [SerializeField]
    Transform lookPoint = null;

    void Start()
    {
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
            instance.gameObject.GetComponent<LetterController>().lookPoint = lookPoint;
            Debug.Log("Created: " + instance.name + " " + instance.GetInstanceID());
            spawnList.RemoveAt(randomIndex);
        }
    }
}
