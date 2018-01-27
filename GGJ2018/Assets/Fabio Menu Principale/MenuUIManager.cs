using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUIManager : MonoBehaviour
{
    public GameObject controllerImage; // Controller Image
    public EventSystem eventSystem; // The Event System
    public GameObject firstSelectedMainMenuButton; // First button selected in the Main Menu
    public GameObject firstSelectedExitMenuButton; // First button selected in the "Security Menu"
    public GameObject firstSelectedControllerMenuButton; // First button selected in the "Controller Menu"
    public Button areYouSureYesButton; // The "Yes Button" in the "Security Menu"
    public Button areYouSureNoButton; // The "No Button" in the "Security Menu"
    public Button mainMenuButton; // The button that allow to disable the "controller image" and allow to go to the main menu

	void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
    }

	public void StartNewGame() // Start new game function
	{
		//SceneManager.LoadSceneAsync(1);
	}

	public void FadesMenu(string menuType) // Set the time to wait until the fade animation is finished
    {
		Invoke("MainMenu", 0.2f);
	}

   public void ControllerImage() // Enabled the Controller Image
    {
        controllerImage.gameObject.SetActive(true);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(firstSelectedControllerMenuButton);
    }

    public void ExitGameMenu() // Enabled the Exit Game Menu and disable all the others
    {
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(true);
        areYouSureNoButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedExitMenuButton); // Set the first selected button in the menu
    }

    public void ExitGameYes() // Exit game
    {
        Application.Quit();
    }

    public void AreYouSureNo() // Back to the main menu
    {
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
    }
}