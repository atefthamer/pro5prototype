using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orbit : MonoBehaviour
{
    public float xzSpread;
    public float yOffset;
    //public Transform centerPoint;
    public GameObject centerPoint;

    public float rotSpeed;
    public bool random = true;


    // Start is called before the first frame update
    void Start()
    {
        if (!random)
        {
            xzSpread = 0.0f;
            yOffset = Random.Range(1.0f, 30.0f);
            //rotSpeed = Random.Range(0.05f, 0.1f);
            rotSpeed = 0.0f;
        }
        else
        {
            xzSpread = Random.Range(-26.0f, 26.0f);
            yOffset = Random.Range(10.0f, 30.0f);
            //rotSpeed = Random.Range(0.05f, 0.1f);
            rotSpeed = Random.Range(2.0f, 8.0f);
        }

        this.gameObject.transform.position = new Vector3(xzSpread, yOffset, xzSpread);

    }

    // Update is called once per frame-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*
    void Update()
    {
        transform.RotateAround(centerPoint.transform.position, new Vector3(0, 3, 0), rotSpeed * Time.deltaTime);
    }

}