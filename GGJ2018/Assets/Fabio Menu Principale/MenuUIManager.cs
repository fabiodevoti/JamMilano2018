using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUIManager : MonoBehaviour
{
    public GameObject controllerImage; // Controller Image
    public GameObject areYouSure; // Security menu which appear only if there is a save file. In case of missing save file, it's doesn't appear
    public EventSystem eventSystem; // The Event System
    public GameObject firstSelectedMainMenuButton; // First button selected in the Main Menu
    public GameObject firstSelectedExitMenuButton; // First button selected in the "Security Menu"
	public Button areYouSureYesButton; // The "Yes Button" in the "Security Menu"
    public Button areYouSureNoButton; // The "No Button" in the "Security Menu"

	void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
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
    }

    public void ExitGameMenu() // Enabled the Exit Game Menu and disable all the others
    {
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(true);
        areYouSureNoButton.gameObject.SetActive(true);
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
        eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
    }
}