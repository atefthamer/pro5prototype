using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Go : MonoBehaviour
{
    public void Pressed()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        bool flip = !renderer.enabled;

        renderer.enabled = flip;
    }
}
