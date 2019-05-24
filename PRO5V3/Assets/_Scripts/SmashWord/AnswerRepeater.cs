using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerRepeater : MonoBehaviour
{
    public AudioClip answer;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            Debug.Log("COLLISION DETECTED");
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(answer);
            StartCoroutine(pressButton());
        }
    }

    private IEnumerator pressButton()
    {
        anim.Play("Repeat_Button_press");
        yield return new WaitForSeconds(1.0f);
        anim.Play("Repeat_Button_idle");
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
