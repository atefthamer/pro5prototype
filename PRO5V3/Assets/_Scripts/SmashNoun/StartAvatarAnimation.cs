using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAvatarAnimation : MonoBehaviour
{

    public Animator animator;
    float InputX;
    float InputY;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }
}
