using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManag : MonoBehaviour {

    public Text score;
    public int total;
	public GameObject restartButton;
	public GameObject win;
	public GameObject npcs;

    [HideInInspector]
    public int cured=0;

	private AudioSource audioS;

    void Start () {

		audioS = GetComponent<AudioSource> ();
	}
	
	void Update () 
	{

        score.text = cured + "     /  " + total;

		if (cured == total) 
		{
			audioS.Play ();
			npcs.SetActive (false);
			restartButton.SetActive (true);
			win.SetActive (true);
		}
    }
}
