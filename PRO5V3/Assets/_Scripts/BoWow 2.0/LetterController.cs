using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [HideInInspector]
    public Transform lookPoint = null;

    void Start()
    {
        transform.LookAt(lookPoint);
    }

    void Update()
    {
        
    }
}
