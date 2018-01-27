using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStartTest : MonoBehaviour {

	public GameObject audioManager;

	// Use this for initialization
	void Start () 
	{
		audioManager.GetComponent<AudioManager>().Play ("Background");
	}

}
