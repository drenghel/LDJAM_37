using System.Collections.Generic;
using UnityEngine;

// ReSharper disable IdentifierTypo
public class BecherList : MonoBehaviour
{
    //public Sprite RedBecherSprite;
    //public Sprite GreenBecherSprite;
    //public Sprite BlueBecherSprite;
    public Sprite EmptyBecherSprite;
    //public Sprite PurpleBecherSprite;
    //public Sprite OrangeBecherSprite;
    //public Sprite YellowBecherSprite;
    //public Sprite BaseBecherSprite;

    private Dictionary<ChemicalType, Color> _colorsDictionary;

    void Awake()
    {
        _colorsDictionary = new Dictionary<ChemicalType, Color>
        {
            {ChemicalType.Base, Color.white},
            {ChemicalType.Red, Color.red},
            {ChemicalType.Blue, Color.blue},
            {ChemicalType.Green, Color.green},
            {ChemicalType.Empty, Color.clear},
            {ChemicalType.None, Color.clear}
        };
    }


    //public Sprite GetSpriteWithType(ChemicalType type)
    //{
    //    switch (type)
    //    {
    //        case ChemicalType.None:
    //            return null;
    //        case ChemicalType.Mixed:
    //            throw new UnityException("Mixed Chemical has not been implemented !");
    //    }

    //    Sprite res;
    //    bool success = _spritesDictionary.TryGetValue(type, out res);
    //    if (success)
    //        return res;
    //    throw new UnityException("There is no " + type + "sprite in the becher list");
    //}


    //public ChemicalType GetTypeOfSprite(Sprite sprite)
    //{
    //    ChemicalType res;
    //    bool success = _typesDictionary.TryGetValue(sprite, out res);
    //    if (success)
    //        return res;
    //    throw new UnityException("There is no " + sprite.name + "type in the becher list");
    //}

    public static BecherList GetBecherList()
    {
        BecherList[] list = FindObjectsOfType<BecherList>();
        if (list.Length > 1)
            throw new UnityException("There can no be more than one becher list !");
        return list[0];
    }

    public Color GetColorWithType(ChemicalType type)
    {
        Color res;
        bool success = _colorsDictionary.TryGetValue(type, out res);
        if (success)
            return res;
        throw new UnityException("There is no " + type + " color in the becher list");
    }


    public static Color CombineColors(params Color[] aColors)
    {
        Color result = new Color(0, 0, 0, 0);
        foreach (Color c in aColors)
        {
            result += c;
        }
        result /= aColors.Length;
        return result;
    }
}