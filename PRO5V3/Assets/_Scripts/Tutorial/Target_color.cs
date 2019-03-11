using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_color : MonoBehaviour
{
    public Material[] mats;
    int value = 0;
    int childNumber = 2;
    [HideInInspector]
    public Transform[] childs;
    public GameObject[] childObjects;
    private float timer = 0.05f;

    void Start()
    {
        childs = gameObject.GetComponentsInChildren<Transform>();
        childObjects = new GameObject[childs.Length];

        foreach (Transform tr in childs)
        {
            value++;
            childObjects.SetValue(tr.gameObject, value - 1);
        }

        //Component[] renderers = this.GetComponentsInChildren(typeof(Renderer));
        //foreach (Renderer childRenderer in renderers)
        //{
        //    childRenderer.material = mats[1];
        //}
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
        {
            NextColor();
            timer = 0.05f;
        }

        //childObjects[childNumber].GetComponent<Renderer>().material = mats[1];

        //for (childNumber = 2; childNumber < 10; childNumber++)
        //{
        //    if (childNumber == childObjects.Length)
        //    {
        //        childNumber = 2;
        //    }

        //    Component[] renderers = this.GetComponentsInChildren(typeof(Renderer));
        //    foreach(Renderer childRenderer in renderers)
        //    {
        //        childRenderer.material = mats[0];
        //    }
        //    childObjects[childNumber].GetComponent<Renderer>().material = mats[1];
        //}
    }

    void NextColor()
    {
        Component[] renderers = this.GetComponentsInChildren(typeof(Renderer));
        foreach(Renderer childRenderer in renderers)
        {
            childRenderer.material = mats[0];
        }

        childObjects[childNumber].GetComponent<Renderer>().material = mats[1];
        childNumber++;

        if (childNumber == childObjects.Length)
        {
            childNumber = 1;
        }
    }
}
