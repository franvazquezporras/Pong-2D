using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectorLevelMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject scorePanel;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            Pause();   
        }
    }
    public void Pause()
    {

        Time.timeScale = 0;
        scorePanel.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void Continue()
    {
        
        pauseMenu.SetActive(false);
        scorePanel.SetActive(true);
        Time.timeScale = 1;
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadSelectorLevel()
    {
        mainMenu.SetActive(false);
        selectorLevelMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        mainMenu.SetActive(true);
        selectorLevelMenu.SetActive(false);
    }

    public void LoadTwoPlayerGame()
    {
        SceneManager.LoadScene("PlayerVsPlayer");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
