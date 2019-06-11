using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabControllerSlash : MonoBehaviour
{
    private Animator rab;
    public List<AudioClip> rabbitClips = new List<AudioClip>();

    void Start()
    {
        rab = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        StartCoroutine(RabbitTalkSequence1());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"));
        {
            StartCoroutine(RabbitTalkSequence1());
            rab.Play("Talking");
        }
    }

    public IEnumerator RabbitTalkSequence1()
    {
        yield return new WaitForSeconds(3.233f);
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(rabbitClips[0]);
    }
}