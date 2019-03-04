using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnArea : MonoBehaviour
{
    public int numObjects = 3;
    public GameObject prefab;
    private List<GameObject> clones;

    void Start()
    {
        Vector3 center = transform.position;
        clones = new List<GameObject>();
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 pos = RandomCircle(center, 5.0f);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            //Instantiate(prefab, pos, rot);
            clones.Add((GameObject)Instantiate(prefab, pos, rot));
            Debug.Log(clones.Count);
        }
        
        for(int i = 0; i < clones.Count; i++)
        {
            clones[i].GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
        //InstantiateCircle();
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        float ang = Random.Range(-90.0f, 90.0f);
        //float ang = Random.value * 360;
        //prefab.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Debug.Log("The Angle: " + ang);
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z + Random.Range(-10.0f, 10.0f);
        return pos;
    }

    //void InstantiateCircle()
    //{
    //    float angle = 360f / (float)numObjects;
    //    Vector3 center = transform.position;
    //    for (int i = 0; i < numObjects; i++)
    //    {
    //        Quaternion rotation = Quaternion.AngleAxis(i * angle, Vector3.up);
    //        Vector3 direction = rotation * Vector3.forward;

    //        Vector3 position = center + (direction * 2);
    //        Instantiate(prefab, position, rotation);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
