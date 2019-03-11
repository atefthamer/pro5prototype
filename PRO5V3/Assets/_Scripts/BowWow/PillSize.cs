using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillSize : MonoBehaviour
{
    public float xScale = 0.0f;
    public float yScale = 0.0f;
    public float zScale = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        xScale = Random.Range(0.3f, 3.0f);
        yScale = Random.Range(0.3f, 3.0f);
        zScale = Random.Range(0.3f, 3.0f);

        ChangeSize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeSize()
    {
        this.gameObject.transform.localScale += new Vector3(xScale, xScale, xScale);
    }
}
