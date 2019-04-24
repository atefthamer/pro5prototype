using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public string ObjectName = "powerstick";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Interactable"))
        {
            Destroy(this.gameObject);
        }
        Debug.Log("COLLISION OBJECT " + col.gameObject.name);
    }

}
