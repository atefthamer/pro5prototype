using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Animation : MonoBehaviour
{
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        this.anim["Idle"].time = 0.0f;
        this.anim.CrossFade("Idle");
    }
}
