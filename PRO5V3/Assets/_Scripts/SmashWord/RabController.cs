using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabController : MonoBehaviour
{
    private Animation anim;
    private Animation rab;
    public GameObject rabbit;
    public bool playani;
    public List<AnimationClip> animclips = new List<AnimationClip>();
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        rab = rabbit.GetComponent<Animation>();
        playani = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playani == true)
        {
            anim.clip = animclips[5];
            rab.clip = animclips[0];
            anim.Play();
            rab.Play();
        }
    }
    public void PlayAnimation()
    {
        playani = true;
    }
}
