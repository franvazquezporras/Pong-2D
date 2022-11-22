using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPaddle : MonoBehaviour
{
    //Variables
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPlayer1;
    private float limitYBound = 3.5f;    


    [SerializeField] private PlayerSkinDataBase skinDB;
    private SpriteRenderer spriteSkin;
    private int selectedSkin = 0;

    //Functions
    private void Awake()
    {
        spriteSkin = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "PlayerVsPlayer")
        {
            if (!PlayerPrefs.HasKey("SelectedSkin"))
                selectedSkin = 0;
            else
                Load();

            UpdateSkin(selectedSkin);
        } 
        
    }
    void Update()
    {
        float movement; 
        if(isPlayer1)
            movement = Input.GetAxisRaw("Vertical");
        else
            movement = Input.GetAxisRaw("Vertical2");

        Vector2 playerPosition = transform.position;        
        playerPosition.y = Mathf.Clamp(playerPosition.y + movement * speed * Time.deltaTime, -limitYBound, limitYBound);
        transform.position = playerPosition;       
    }
    public void SetLimitYBound(float limit)
    {
        limitYBound = limit;
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
}
