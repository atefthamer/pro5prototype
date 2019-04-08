using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowards : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField]
    public Transform target;

    public float speed = 5.0f;
    // Update is called once per frame
    void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = speed * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
