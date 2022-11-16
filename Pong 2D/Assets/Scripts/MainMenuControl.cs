using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject SelectorLevelMenu;


    private void Start()
    {
        LoadMainMenu();
    }

    public void LoadSelectorLevel()
    {
        MainMenu.SetActive(false);
        SelectorLevelMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        MainMenu.SetActive(true);
        SelectorLevelMenu.SetActive(false);
    }

    public void LoadTwoPlayerGame()
    {
        SceneManager.LoadScene("GameLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
