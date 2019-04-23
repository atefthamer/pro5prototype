using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EventCallbacks
{
    public class PlaySound : MonoBehaviour
    {
        // Start is called before the first frame update
        //[SerializeField]
        public AudioSource audioData;
        [SerializeField]
        AudioClip clip;

        void Start()
        {
            audioData = GetComponent<AudioSource>();
            //audioData.clip = clip;
            //audioData.Play(0);
            Debug.Log("started");
        }

        // Update is called once per frame
        void Update()
        {
            //audioData.Play(0);
        }

        public void PlayTheDamnSound()
        {
            Debug.Log("Play Sound");
            audioData.Play(0);
        }
    }
}