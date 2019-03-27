using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToSpeech : MonoBehaviour
{
    public AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
        StartCoroutine(DownloadTheAudio());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DownloadTheAudio(){
        string url = "https://translate.google.com/translate_tts?ie=UTF-8&client=tw-ob&tl=nl&q=Vliegtuig";
        WWW www = new WWW(url);
        yield return www;
        _audio.clip = www.GetAudioClip(false, true,AudioType.MPEG);
        _audio.Play();
      
    }
}
