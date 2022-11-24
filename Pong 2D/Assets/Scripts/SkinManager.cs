using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinManager : MonoBehaviour
{
    //Variables
    [SerializeField] private PlayerSkinDataBase skinDB;
    [SerializeField] private Image spriteSkin;
    private int selectedSkin = 0;


    /*********************************************************************************************************************************/
    /*Funcion: Start                                                                                                                 */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Comprueba si existe algun index guardado en el playerpref, si no existe carga el primer index por defecto         */
    /*********************************************************************************************************************************/
    private void Start()
    {
        if (!PlayerPrefs.HasKey("SelectedSkin"))
            selectedSkin = 0;
        else
            Load();

        UpdateSkin(selectedSkin);
    }


    /*********************************************************************************************************************************/
    /*Funcion: NextOption                                                                                                            */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Modifica el index y lo aumenta, en caso de llegar al maximo numero de skins o al numero de skins desbloqueadas    */
    /*             pone a 0 el index para ir al primero llama a la funcion para cargar la nueva skin y guardar                       */
    /*********************************************************************************************************************************/
    public void NextOption()
    {
        selectedSkin++;        
        if (selectedSkin >= skinDB.SkinCount || selectedSkin > PlayerPrefs.GetInt("UnlockedLevels"))
            selectedSkin = 0;

        UpdateSkin(selectedSkin);
        Save();
    }


    /*********************************************************************************************************************************/
    /*Funcion: BackOption                                                                                                            */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Modifica el index y lo decrementa, en caso de llegar a 0 carga la ultima skin desbloqueada                        */
    /*             llama a la funcion para cargar la nueva skin y guardar                                                            */
    /*********************************************************************************************************************************/
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

    /*********************************************************************************************************************************/
    /*Funcion: UpdateSkin                                                                                                            */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: Index de skin actual                                                                                    */
    /*Descripción: Recibe la skin selecciona del array y la cambia en el personaje                                                   */
    /*********************************************************************************************************************************/
    private void UpdateSkin(int selected)
    {
        PlayerSkin skin = skinDB.GetSkin(selected);
        spriteSkin.sprite = skin.skin;        
    }

    /*********************************************************************************************************************************/
    /*Funcion: Load                                                                                                                  */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Carga el index que hay guardado en el playerpref de la skin seleccionada                                          */
    /*********************************************************************************************************************************/
    private void Load()
    {
        selectedSkin = PlayerPrefs.GetInt("SelectedSkin");
    }

    /*********************************************************************************************************************************/
    /*Funcion: Save                                                                                                                  */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Descripción: Guarda la ultima skin seleccionada en el playerpref                                                               */
    /*********************************************************************************************************************************/
    private void Save()
    {
        PlayerPrefs.SetInt("SelectedSkin", selectedSkin);
    }

    
}
