using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {


	public static AudioClip ShootAudio;
	public static AudioClip ReloadAudio;
	public static AudioClip Walkaudio;
	public static AudioClip grabaudio;
	public static AudioClip wallstrikeaudio;

	public static AudioSource audiosource;

	// Use this for initialization
	void Start () 
	{
		audiosource = GetComponent<AudioSource> ();
		ShootAudio = Resources.Load<AudioClip> ("Audio/ShootAudio");
		ReloadAudio = Resources.Load<AudioClip> ("Audio/ReloadAudio");
		Walkaudio = Resources.Load<AudioClip> ("Audio/WalkAudio");
		grabaudio = Resources.Load<AudioClip> ("Audio/GrabAudio");
		wallstrikeaudio = Resources.Load<AudioClip> ("Audio/WallStrikeAudio");
		
		
	}
	
	// Update is called once per frame

	public static void PlayAudio(string clip)
	{
		switch(clip)
		{

		case"Reload":
			audiosource.PlayOneShot (ReloadAudio);
			break;
		case"Shoot":
			audiosource.PlayOneShot (ShootAudio);
			break;
		case"Walk":
			audiosource.PlayOneShot (Walkaudio);
			break;
		case"Grab":
			audiosource.PlayOneShot (grabaudio);
			break;
		case"WallStrike":
			audiosource.PlayOneShot (wallstrikeaudio);
			break;

		}
			
	}
		
}
