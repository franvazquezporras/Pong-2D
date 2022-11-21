using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinManager : MonoBehaviour
{
    [SerializeField] private PlayerSkinDataBase skinDB;
    [SerializeField] private Image spriteSkin;

    private int selectedSkin = 0;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("SelectedSkin"))
            selectedSkin = 0;
        else
            Load();

        UpdateSkin(selectedSkin);
    }

    public void NextOption()
    {
        selectedSkin++;        
        if (selectedSkin >= skinDB.SkinCount || selectedSkin > PlayerPrefs.GetInt("UnlockedLevels"))
            selectedSkin = 0;

        UpdateSkin(selectedSkin);
        Save();
    }
    public void BackOption()
    {
        selectedSkin--;
        if (selectedSkin < 0)
        {
            if (skinDB.SkinCount - 1 > PlayerPrefs.GetInt("UnlockedLevels"))
                selectedSkin = PlayerPrefs.GetInt("UnlockedLevels");
            else
                selectedSkin = skinDB.SkinCount - 1;
        }
        UpdateSkin(selectedSkin);
        Save();
    }
    private void UpdateSkin(int selected)
    {
        PlayerSkin skin = skinDB.GetSkin(selected);
        spriteSkin.sprite = skin.skin;        
    }

    private void Load()
    {
        selectedSkin = PlayerPrefs.GetInt("SelectedSkin");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedSkin", selectedSkin);
    }

    
}
