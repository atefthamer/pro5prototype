using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Orbit : MonoBehaviour
{
    public float xSpread;
    public float zSpread;
    public float yOffset;
    //public Transform centerPoint;
    public GameObject centerPoint;

    public float rotSpeed;
    public bool rotateClockwise;
    public bool random = true;

    float timer = 0;
    Vector3 center;
    private Vector3 position;
    float radius = 0.0f;

    //public Orbit()
    //{
    //    this.radius = Random.Range(0.5f, 5.0f);
    //    this.center = centerPoint.transform.position;
    //    this.radius = Random.Range(0.5f, 5.0f);
    //    this.position = RandomCircle(center, radius);
    //}

    // Start is called before the first frame update
    void Start()
    {


        //position =  this.gameObject.GetComponent<LoadLetters>().RandomCircle(center, radius);

        if (!random)
        {
            xSpread = 0.0f;
            zSpread = 0.0f;
            yOffset = Random.Range(1.0f, 15.0f);
            //rotSpeed = Random.Range(0.05f, 0.1f);
            rotSpeed = 0.0f;
        }
        else
        {
            xSpread = Random.Range(15.0f, 40.0f);
            zSpread = Random.Range(14.0f, 40.0f);
            yOffset = Random.Range(1.0f, 15.0f);
            //rotSpeed = Random.Range(0.05f, 0.1f);
            rotSpeed = Random.Range(0.05f, 0.1f);
        }

    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotSpeed;
        //position = RandomCircle(center, radius);
        Rotate();
    }

    void Rotate()
    {
        var trans = centerPoint.transform.position;

        if (rotateClockwise)
        {
            float x = -Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            //this.gameObject.transform.position = pos + centerPoint.position;
            //this.gameObject.transform.position = pos + trans;
            this.gameObject.transform.position = pos + trans;
        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            //this.gameObject.transform.position = pos + centerPoint.position;
            //this.gameObject.transform.position = pos + trans;
            this.gameObject.transform.position = pos + trans;
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("projectile"))
    //    {
    //        Debug.Log("Letter Hit");
    //        Destroy(this.gameObject);
    //        Destroy(other.gameObject);
    //    }
    //}

    public Vector3 RandomCircle(Vector3 center, float radius)
    {
        //float ang = UnityEngine.Random.Range(-90.0f, 90.0f) * 360;
        float ang = UnityEngine.Random.value * 360;
        //prefab.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //Debug.Log("The Angle: " + ang);
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        //pos.z = center.z + UnityEngine.Random.Range(-5.0f, 60.0f);
        pos.z = center.z * UnityEngine.Random.Range(5.0f, 50.0f);
        return pos;
    }
}
