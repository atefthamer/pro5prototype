using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [HideInInspector]
    public Transform lookPoint = null;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(lookPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
