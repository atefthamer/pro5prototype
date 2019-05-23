using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabController : MonoBehaviour
{
    private Animator anim;
    private Animator rab;
    public GameObject rabbit;
    //public bool playani;
    // public List<AnimationClip> animclips = new List<AnimationClip>();
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rab = rabbit.GetComponent<Animator>();
        //playani = false;
    }

    public IEnumerator RabbitTalkSequence()
    {
        anim.Play("Ani_bundle_bunny");
        rab.Play("Jumping Up");
        yield return new WaitForSeconds(3.233f);
        rab.Play("Talking");
        anim.Play("ani_idle_bunny");
        yield return new WaitForSeconds(10.267f);
        anim.Play("Ani_down_bunny");
        rab.Play("Jumping Down");
        yield return new WaitForSeconds(2.933f);
        rab.Play("Idle");
        anim.Play("EmptyState");
    }
}