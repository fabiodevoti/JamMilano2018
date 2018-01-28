using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManag : MonoBehaviour {

    public Text score;
    public int total;
    public Text loadBar;
    [HideInInspector]
    public int cured=0;

    

    void Start () {
		
	}
	
	void Update () {

        score.text = cured + " / " + total;


    }
}
