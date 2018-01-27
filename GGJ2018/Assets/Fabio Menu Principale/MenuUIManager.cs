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
    public Button exitGameButton; // The button that allow to disable the "controller image" and allow to go to the main menu

	void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        startGameButton.gameObject.SetActive(true);
        exitGameButton.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
    }

	public void StartNewGame() // Start new game function
	{
		//SceneManager.LoadSceneAsync(1);
	}

    public void ExitGame() // Exit game
    {
        Application.Quit();
    }
}