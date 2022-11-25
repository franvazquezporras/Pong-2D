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




    /*********************************************************************************************************************************/
    /*Funcion: Awake                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripci�n: Asigna las referencias de la variable sprite                                                                      */
    /*********************************************************************************************************************************/
    private void Awake()
    {
        spriteSkin = GetComponent<SpriteRenderer>();
    }


    /*********************************************************************************************************************************/
    /*Funcion: Start                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripci�n: Comprueba si la escena actual no es la del playerVsPlayer para cargar la skin seleccionada                        */
    /*********************************************************************************************************************************/
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


    /*********************************************************************************************************************************/
    /*Funcion: Update                                                                                                                */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripci�n: Actualiza la posicion del jugador mientras se presiones las teclas de movimiento del jugador controlando el       */
    /*             limite superior e inferior (las paredes) para que el jugador no salga del mapa                                    */
    /*********************************************************************************************************************************/
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


    /*********************************************************************************************************************************/
    /*Funcion: SetLimitYBound                                                                                                        */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripci�n: Actualiza la variable limite                                                                                      */
    /*********************************************************************************************************************************/
    public void SetLimitYBound(float limit)
    {
        limitYBound = limit;
    }


    /*********************************************************************************************************************************/
    /*Funcion: UpdateSkin                                                                                                            */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: skin seleccionada                                                                                       */
    /*Descripci�n: Actualiza la skin del jugador                                                                                     */
    /*********************************************************************************************************************************/
    private void UpdateSkin(int selected)
    {
        PlayerSkin skin = skinDB.GetSkin(selected);
        spriteSkin.sprite = skin.skin;
    }

    /*********************************************************************************************************************************/
    /*Funcion: Load                                                                                                                  */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripci�n: Carga el playerpref que contiene la ultima skin seleccionada en la variable del player                            */
    /*********************************************************************************************************************************/
    private void Load()
    {
        selectedSkin = PlayerPrefs.GetInt("SelectedSkin");
    }
}
