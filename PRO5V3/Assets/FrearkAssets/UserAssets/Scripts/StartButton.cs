using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour 
{
	public Color color = Color.green;
	public static bool EngineRunning = false;
	public Animator anim;
	public GameObject Gashandel;

	//private bool ButtonEngineStop = false;



	public AudioClip clipButton;
	public AudioClip clipEngine;

	private AudioSource audioButton;
	public AudioSource audioEngine;

	public AudioSource AddAudio(AudioClip clip, bool loop, bool playAwake, float vol)
	{
		AudioSource newAudio =  gameObject.AddComponent<AudioSource>();
		newAudio.clip = clip;
		newAudio.loop = loop;
		newAudio.playOnAwake = playAwake;
		newAudio.volume = vol;
		return newAudio;
	}


	void Awake()
	{
		//source = GetComponent<AudioSource> ();
		audioButton = AddAudio(clipButton,false, false, 1.0f);
		audioEngine = AddAudio(clipEngine,true, false, 0.25f);
	}

	void start()
	{
		anim = GetComponent <Animator>();
		gameObject.GetComponent<Renderer> ().material.color = Color.green;
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Controller (right)") 
		{
			if (EngineRunning == false) 
			{
				EngineRunning = true;
				anim.Play ("StartButton");
				audioButton.Play ();
				audioEngine.pitch = 0.15f;
				audioEngine.Play ();
				//source.Play ();
				//source.PlayOneShot(ButtonSound, 1.0f);
				//source.PlayOneShot (StartEngine, 1.0f);
				gameObject.GetComponent<Renderer> ().material.color = Color.red;
			}
			else
			{
				EngineRunning = false;
				anim.Play ("StartButton");
				audioButton.Play ();
				audioEngine.Stop ();
				//source.Play ();
				//source.PlayOneShot (ButtonSound, 1.0f);
				Gashandel.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
				gameObject.GetComponent<Renderer> ().material.color = Color.green;
			}	


		}
	}
	/*
	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "Controller (right)") 
		{
			anim.Play ("AnimationIdleButton");
		}
	}
*/


	void Update()
	{
		if (anim.GetCurrentAnimatorStateInfo (0).IsName("StartButton") && anim.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.9f) 
		{
			anim.Play ("AnimationIdleButton");
		}



		
		if(Input.GetKeyDown("1"))
		{
			anim.Play ("StartButton");
		}
		if(Input.GetKeyDown("2"))
		{
			anim.Play ("AnimationIdleButton");
		}

	}


}
