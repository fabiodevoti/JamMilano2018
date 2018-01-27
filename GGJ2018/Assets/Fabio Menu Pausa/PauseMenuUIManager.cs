using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuUIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject backToGame;
    public GameObject backToMainMenu;
    public GameObject controllerImage;
    public EventSystem eventSystem; // The Event System
    public GameObject firstSelectedPauseMenuButton; // First button selected in the Main Menu
    public GameObject firstSelectedControllerMenuButton; // First button selected in the "Controller Menu"
    public GameObject firstSelectedExitMenuButton; // First button selected in the "Security Menu"
    public Button areYouSureYesButton; // The "Yes Button" in the "Security Menu"
    public Button areYouSureNoButton; // The "No Button" in the "Security Menu"
    public Button backToPauseMenuButton; // The button that allow to disable the "controller image" and allow to go to the main menu

    void Start()
    { }

    public void PausePanelEnable() // Enable the pause panel
    {
        pausePanel.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(firstSelectedPauseMenuButton);
        backToGame.gameObject.SetActive(true);
        backToMainMenu.gameObject.SetActive(true);
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
        backToPauseMenuButton.gameObject.SetActive(false);
    }

    public void ControllerImage() // Enabled the Controller Image
    {
        backToGame.gameObject.SetActive(false);
        backToMainMenu.gameObject.SetActive(false);
        controllerImage.gameObject.SetActive(true);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
        backToPauseMenuButton.gameObject.SetActive(true);
        eventSystem.SetSelectedGameObject(firstSelectedControllerMenuButton);   
    }

    public void BackToGame ()
    {
        pausePanel.gameObject.SetActive(false);
    }

    public void BackToMainMenuChoice ()
    {
        backToGame.gameObject.SetActive(true);
        backToMainMenu.gameObject.SetActive(true);
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
        backToPauseMenuButton.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedExitMenuButton);
    }

    public void AreYouSureYes ()
    {
        //SceneManager.LoadSceneAsync(1);
    }

    public void FadesMenu(string menuType) // Set the time to wait until the fade animation is finished
    {
        Invoke("MainMenu", 0.2f);
    }

    public void AreYouSureNo ()
    {
        eventSystem.SetSelectedGameObject(firstSelectedPauseMenuButton);
        backToGame.gameObject.SetActive(true);
        backToMainMenu.gameObject.SetActive(true);
        controllerImage.gameObject.SetActive(false);
        areYouSureYesButton.gameObject.SetActive(false);
        areYouSureNoButton.gameObject.SetActive(false);
        backToPauseMenuButton.gameObject.SetActive(false);
    }
}