using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePill : MonoBehaviour
{
    private int xValue = 5;
    private int yValue = 5;

    public float speed = 0.0f;
    public float width = 0.0f;
    public float height = 0.0f;

    private float timeCounter = 0f;
    private Vector3 randomRotation;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1.0f, 2.0f);
        width = Random.Range(3.0f, 5.0f);
        height = Random.Range(7.0f, 9.0f);

        //float xRot = Random.Range(0.5f, 2.0f);
        float xRot = 0.0f;
        //float yRot = Random.Range(0.5f, 2.0f);
        float yRot = 5.0f;
        //float zRot = Random.Range(0.5f, 2.0f);
        float zRot = 0.0f;

        randomRotation = new Vector3(xRot, yRot, zRot);
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        //xValue = (int)Random.Range(0.1f, 0.5f);
        xValue = 0;
        //yValue = (int)Random.Range(0.1f, 0.1f);
        yValue = 0;

        float x = Mathf.Cos(timeCounter) * width;
        float y = Mathf.Sin(timeCounter) * height;
        float z = Mathf.Sin(timeCounter) * 0.0f;

        //this.gameObject.transform.position = new Vector3(x, y, z);
        this.gameObject.transform.Rotate(randomRotation * Time.deltaTime * speed, Space.World);
        this.gameObject.transform.Rotate(randomRotation * Time.deltaTime * speed);
        //this.gameObject.transform.Rotate(Time.deltaTime, xValue, yValue);
        //this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(20.0f, 10.0f, 0f);
        //this.gameObject.transform.position = Quaternion.AngleAxis(timeCounter, Vector3.forward) * new Vector3(10.0f, 0f);
    }
}
