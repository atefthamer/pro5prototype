using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabController : MonoBehaviour
{
    private Animator anim;
    private Animator rab;

    private bool animationPlaying = false;

    public GameObject rabbit;
    public BarrelManager bMan;

    public List<AudioClip> rabbitClips = new List<AudioClip>();

    void Start()
    {
        anim = GetComponent<Animator>();
        rab = rabbit.GetComponent<Animator>();
    }

    public IEnumerator RabbitTalkSequence1()
    {
        anim.Play("Ani_bundle_bunny");
        rab.Play("Jumping Up");
        yield return new WaitForSeconds(3.233f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[0]);
        rab.Play("Talking");
        anim.Play("ani_idle_bunny");
        yield return new WaitForSeconds(9.805f);
        anim.Play("Ani_down_bunny");
        rab.Play("Jumping Down");
        yield return new WaitForSeconds(2.933f);
        rab.Play("Idle");
        anim.Play("EmptyState");
        bMan.barrelHit = false;
        bMan.firstGroupHit = true;
        bMan.PlayQuestion(2);
    }

    public IEnumerator RabbitTalkSequence2()
    {
        anim.Play("Ani_bundle_bunny");
        rab.Play("Jumping Up");
        yield return new WaitForSeconds(3.233f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[1]);
        rab.Play("Talking");
        anim.Play("ani_idle_bunny");
        yield return new WaitForSeconds(20.095f);
        anim.Play("Ani_down_bunny");
        rab.Play("Jumping Down");
        yield return new WaitForSeconds(2.933f);
        rab.Play("Idle");
        anim.Play("EmptyState");
        bMan.barrelHit = false;
        bMan.secondGroupHit = true;
        StartCoroutine(bMan.QuestionNumerator(5));
    }

    public IEnumerator RabbitTalkSequence3()
    {
        anim.Play("Ani_bundle_bunny");
        rab.Play("Jumping Up");
        yield return new WaitForSeconds(3.233f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[2]);
        rab.Play("Talking");
        anim.Play("ani_idle_bunny");
        yield return new WaitForSeconds(11.001f);
        anim.Play("Ani_down_bunny");
        rab.Play("Jumping Down");
        yield return new WaitForSeconds(2.933f);
        rab.Play("Idle");
        anim.Play("EmptyState");
        bMan.barrelHit = false;
        bMan.thirdGroupHit = true;
        bMan.PlayQuestion(9);
    }
}
