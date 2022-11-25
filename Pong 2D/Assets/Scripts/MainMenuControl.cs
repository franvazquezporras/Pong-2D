using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class MainMenuControl : MonoBehaviour
{

    //Variables
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject selectorLevelMenu;
    [SerializeField] private GameObject selectorSkinMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject scorePanel;


    /*********************************************************************************************************************************/
    /*Funcion: Start                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Al iniciar la escena del menu principal asegura que cargue el canvas del mismo menu principal                     */
    /*********************************************************************************************************************************/
    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
            LoadMainMenu();
    }


    /*********************************************************************************************************************************/
    /*Funcion: Update                                                                                                                */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Si se presiona la tecla P en una escena que no sea el menu principal pausa el juego                               */
    /*********************************************************************************************************************************/
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            Pause();   
        }
    }

    /*********************************************************************************************************************************/
    /*Funcion: Pause                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Para el tiempo de juego y muestra el menu de pausa y oculta el marcador                                           */
    /*********************************************************************************************************************************/
    public void Pause()
    {

        Time.timeScale = 0;
        scorePanel.SetActive(false);
        pauseMenu.SetActive(true);
    }

    /*********************************************************************************************************************************/
    /*Funcion: Continue                                                                                                              */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Oculta el menu de pause, muestra el marcador y activa el juego nuevamente                                         */
    /*********************************************************************************************************************************/
    public void Continue()
    {
        
        pauseMenu.SetActive(false);
        scorePanel.SetActive(true);
        Time.timeScale = 1;
    }

    /*********************************************************************************************************************************/
    /*Funcion: GoToMainMenu                                                                                                          */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Desde el menu de pausa activa el juego y carga la escena menu principal                                           */
    /*********************************************************************************************************************************/
    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");        
    }


    /*********************************************************************************************************************************/
    /*Funcion: Retry                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Reinicia el nivel actual                                                                                          */
    /*********************************************************************************************************************************/
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    /*********************************************************************************************************************************/
    /*Funcion: LoadSelectorLevel                                                                                                     */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Oculta los canvas de menu principal y selector de skin y muestra el menu de seleccion de niveles                  */
    /*********************************************************************************************************************************/
    public void LoadSelectorLevel()
    {
        mainMenu.SetActive(false);
        selectorLevelMenu.SetActive(true);
        selectorSkinMenu.SetActive(false);
    }

    /*********************************************************************************************************************************/
    /*Funcion: LoadMainMenu                                                                                                          */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Oculta los canvas de menu de seleccion de niveles y selector de skin y muestra el menu principal                  */
    /*********************************************************************************************************************************/
    public void LoadMainMenu()
    {
        mainMenu.SetActive(true);
        selectorLevelMenu.SetActive(false);
        selectorSkinMenu.SetActive(false);
    }

    /*********************************************************************************************************************************/
    /*Funcion: LoadSelectorSkin                                                                                                      */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Oculta los canvas de menu de seleccion de niveles y menu principal y muestra el selector de skin                  */
    /*********************************************************************************************************************************/
    public void LoadSelectorSkin()
    {
        mainMenu.SetActive(false);
        selectorLevelMenu.SetActive(false);
        selectorSkinMenu.SetActive(true);
    }

    /*********************************************************************************************************************************/
    /*Funcion: LoadTwoPlayerGame                                                                                                     */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Carga la escena de jugador contra jugador                                                                         */
    /*********************************************************************************************************************************/
    public void LoadTwoPlayerGame()
    {
        SceneManager.LoadScene("PlayerVsPlayer");
    }

    /*********************************************************************************************************************************/
    /*Funcion: LoadTwoPlayerGame                                                                                                     */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Cierra la aplicacion                                                                                              */
    /*********************************************************************************************************************************/
    public void Quit()
    {
        Application.Quit();
    }
}
