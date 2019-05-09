using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour 
{
	public GameObject Gashandel;
	public GameObject startButton;

	public float PropSpeed = 100.0f;

	public  AudioClip propsound;
	private AudioSource source;
	private StartButton startButtonScript;

	private bool once = true;

	public float pitc = 1.0f;

	void Awake()
	{
		source = GetComponent<AudioSource> ();

	}

	void start()
	{
		//source.Play ();
		startButtonScript = GameObject.Find("StartButton").GetComponent<StartButton>();
	}

	void Update () 
	{
		
		if (StartButton.EngineRunning == true) 
		{
			source.pitch = Gashandel.transform.localPosition.z * 5.0f;

			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, (transform.localEulerAngles.y + (Gashandel.transform.localPosition.z * PropSpeed)), transform.localEulerAngles.z);
			if (once == true) {
				//source.PlayOneShot (propsound, 0.25F);
				source.Play ();

				//Als Gashandel naar voren wordt geschoven, gaat de pitch omhoog
				//en moet het geluid van de stationair lopende motor stoppen
				if(source.pitch > 0.15f)
				{
					startButtonScript.audioEngine.Stop();
				}
				once = false;
			}
		} 
		else
		{
			source.Stop();
			once = true;
		}

	}
}
