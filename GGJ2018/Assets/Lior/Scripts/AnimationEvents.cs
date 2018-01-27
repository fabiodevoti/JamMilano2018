using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour 
{
	public  AudioClip[] clips;

	public void Step1()
	{
		GetComponent<AudioSource>().clip = clips[0];
		GetComponent<AudioSource> ().Play();
	}

	public void Step2()
	{
		GetComponent<AudioSource>().clip = clips[1];
		GetComponent<AudioSource> ().Play();
	}
}
