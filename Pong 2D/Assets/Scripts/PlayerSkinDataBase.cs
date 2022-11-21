using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSkinDataBase : ScriptableObject
{
    public PlayerSkin[] skins;

    public int SkinCount
    {
        get
        {
            return skins.Length;
        }
    }

    public PlayerSkin GetSkin(int index)
    {
        return skins[index];
    }
}
