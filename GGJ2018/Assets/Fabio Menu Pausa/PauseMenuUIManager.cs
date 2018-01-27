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

    void Start()
    { }

    public void PausePanelEnable()
    {
        pausePanel.gameObject.SetActive(true);
    }

    public void BackToGame ()
    {
        pausePanel.gameObject.SetActive(false);
    }

    public void BackToMainMenu ()
    {
        //SceneManager.LoadSceneAsync(1);
    }
}