using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))   // PAUSE
        {
            Time.timeScale = 0;
        }
		
	}
}
