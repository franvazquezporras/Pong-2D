using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectorLevel : MonoBehaviour
{

    Button[] levelButtons;
    private void Awake()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 1);
        if (PlayerPrefs.GetInt("Level") >= 2)
            unlockedLevels = PlayerPrefs.GetInt("Level");

        levelButtons = new Button[transform.childCount];
        for(int actualLevel=0; actualLevel < levelButtons.Length; actualLevel++)
        {
            levelButtons[actualLevel] = transform.GetChild(actualLevel).GetComponent<Button>();
            levelButtons[actualLevel].GetComponentInChildren<Text>().text = (actualLevel + 1).ToString();
            if (actualLevel + 1 > unlockedLevels)
            {
                levelButtons[actualLevel].interactable = false;
            }
        }
        
    }

    public void LoadLevel(int level)
    {        
        PlayerPrefs.SetInt("Level", level);
        Application.LoadLevel(level);        
    }


    public void nextLevel()
    {        
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedLevels"))        
            PlayerPrefs.SetInt("UnlockedLevels", PlayerPrefs.GetInt("UnlockedLevels") + 1);  
        else if(SceneManager.GetActiveScene().buildIndex == 8)
            Application.LoadLevel(0);
        else
            LoadLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
