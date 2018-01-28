using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUIManager : MonoBehaviour
{
    public EventSystem eventSystem; // The Event System
    public GameObject firstSelectedMainMenuButton; // First button selected in the Main Menu
    public Button startGameButton; // The "Yes Button" in the "Security Menu"
    public GameObject controlsImage;
    public GameObject exitToMainMenuButton;
    public Button exitGameButton; // The button that allow to disable the "controller image" and allow to go to the main menu

    public AudioClip background;
    

	void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        controlsImage.gameObject.SetActive(false);
        exitToMainMenuButton.gameObject.SetActive(false);
    }
    

    public void StartNewGame() // Start new game function
	{
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().clip = background;
        GetComponent<AudioSource>().Play();

    }

    public void ShowControls()
    {
        controlsImage.gameObject.SetActive(true);
        exitToMainMenuButton.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(exitToMainMenuButton);
    }

    public void CloseControls()
    {
        controlsImage.gameObject.SetActive(false);
        exitToMainMenuButton.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
    }

    public void ExitGame() // Exit game
    {
        Application.Quit();
    }
}