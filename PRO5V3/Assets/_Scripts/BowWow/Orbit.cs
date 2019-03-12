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

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        xSpread = Random.Range(15.0f, 40.0f);
        zSpread = Random.Range(14.0f, 40.0f);
        yOffset = Random.Range(1.0f, 15.0f);
        //rotSpeed = Random.Range(0.05f, 0.1f);
        rotSpeed = Random.Range(0.05f, 0.1f);
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * rotSpeed;
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
            this.gameObject.transform.position = pos + trans;
        }
        else
        {
            float x = Mathf.Cos(timer) * xSpread;
            float z = Mathf.Sin(timer) * zSpread;
            Vector3 pos = new Vector3(x, yOffset, z);
            //this.gameObject.transform.position = pos + centerPoint.position;
            this.gameObject.transform.position = pos + trans;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("projectile"))
        {
            Debug.Log("Letter Hit");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
