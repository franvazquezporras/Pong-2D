using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSkinDataBase : ScriptableObject
{
    //Variables
    public PlayerSkin[] skins;

    public int SkinCount
    {
        get
        {
            return skins.Length;
        }
    }
    /*********************************************************************************************************************************/
    /*Funcion: GetSkin                                                                                                               */
    /*Desarrollador: Vazquez                                                                                                         */
    /*Parametros de entrada: Indice                                                                                                  */ 
    /*Descripción: Devuelve la posicion Indice del array con la skin                                                                 */
    /*********************************************************************************************************************************/
    public PlayerSkin GetSkin(int index)
    {
        return skins[index];
    }
}
