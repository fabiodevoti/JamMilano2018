using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashManager : MonoBehaviour {
    
    public EventSystem eventSystem; // The Event System
    public GameObject player;
    public GameObject startImage;
    public GameObject controlsImage;
    public GameObject controlsAnim;
    public GameObject controlsAnim2;
	public GameObject controlsAnim3;
    public GameObject exitImage;

    private AudioSource audioS;

    private int priority;       // 1 - PLAY
                                // 2 - CONTROLS
                                // 3 - EXIT
                                // 4 - BACK (from the controls)


    void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        audioS = GetComponent<AudioSource>();
        SetPriority(1);
        
    }

    void Update()
    {
        if (priority != 0)
        {

            if (priority == 1)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    SetPriority(0); // as a form of hiding everything
           

                    //TODO roba
                    StartNewGame();

                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    SetPriority(2);
                }
            }
            else if (priority == 2)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    SetPriority(4);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    SetPriority(1);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    SetPriority(3);
                }
            }
            else if (priority == 3)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    ExitGame();
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    SetPriority(2);
                }
            }
            else if (priority == 4 && Input.anyKeyDown)
            {
                SetPriority(1);
            }
        }  
    }


    public void SetPriority(int next)
    {
        audioS.Play();
        startImage.gameObject.SetActive(false);
        controlsImage.gameObject.SetActive(false);
        exitImage.gameObject.SetActive(false);
        controlsAnim.gameObject.SetActive(false);
        controlsAnim2.gameObject.SetActive(false);
		controlsAnim3.gameObject.SetActive(false);

        if (next == 1) startImage.gameObject.SetActive(true);
        if (next == 2) controlsImage.gameObject.SetActive(true);
        if (next == 3) exitImage.gameObject.SetActive(true);
        if (next == 4)
        {
            controlsAnim.gameObject.SetActive(true);
            controlsAnim2.gameObject.SetActive(true);
			controlsAnim3.gameObject.SetActive(true);
        }

        priority = next;

    }

    public void StartNewGame() // Start new game function
    {
        SceneManager.LoadScene(1);
        /*Camera.main.GetComponent<CameraFollow>().enabled = true;
        Camera.main.GetComponent<CameraFollow>().SetSpeedTransition();
        player.GetComponent<Player>().canMove = true;
        
        Debug.Log("sono partito!");

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = background;
        GetComponent<AudioSource>().Play();

    */
    }

    public void ExitGame() // Exit game
    {
        Application.Quit();
    }
}
