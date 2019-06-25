using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZepplin : MonoBehaviour
{
    public GameObject zeppelin;
    public GameObject startLocation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == zeppelin)
        {
            zeppelin.transform.position = startLocation.transform.position;
        }
    }
}
