using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{
    //Variables
    [SerializeField] private AudioClip gameMusic;
    [SerializeField] private AudioClip menuMusic;
    private AudioSource audioSource;

    /*********************************************************************************************************************************/
    /*Funcion: Start                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Define el valor del componente AudioSource, y según la escena envia un valor u otro a la funcion PlayMusicManager */
    /*********************************************************************************************************************************/
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().name == "MainMenu")
            PlayMusicManager(2);
        else
            PlayMusicManager(1);

    }

    /*********************************************************************************************************************************/
    /*Funcion: PlayMusicManager                                                                                                      */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: numero de pista                                                                                         */
    /*Descripción: Activa la musica de fondo segun el valor recibido por el parametro de entrada                                     */
    /*********************************************************************************************************************************/
    private void PlayMusicManager(int song)
    {
        switch (song)
        {
            case 1:
                audioSource.clip = gameMusic;
                break;
            case 2:
                audioSource.clip = menuMusic;
                break;
        }
        audioSource.Play();
    }
}
