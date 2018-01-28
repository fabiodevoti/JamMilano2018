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

    

    void Start () {
		
	}
	
	void Update () 
	{

        score.text = cured + "     /  " + total;

		if (cured == total) 
		{
			npcs.SetActive (false);
			restartButton.SetActive (true);
			win.SetActive (true);
		}
    }
}
