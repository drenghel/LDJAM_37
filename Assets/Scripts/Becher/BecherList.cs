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
    private Dictionary<Color, ChemicalType> _typeDictionary;

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
        _typeDictionary = new Dictionary<Color, ChemicalType>
        {
            {Color.white, ChemicalType.Base},
            {Color.red, ChemicalType.Red},
            {Color.blue, ChemicalType.Blue},
            {Color.green, ChemicalType.Green}
            //{Color.clear, ChemicalType.Empty},
            //{Color.clear, ChemicalType.None}
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


    public bool GetTypeByColor(Color color, out ChemicalType chemicalType)
    {
        if (color == Color.clear)
        {
            Debug.Log("You're trying to get a type from a clear color that can't be done");
            chemicalType = ChemicalType.None;
            return false; 
        }
        ChemicalType res;
        bool success = _typeDictionary.TryGetValue(color, out res);
        if (!success)
            Debug.Log("There is no color :" + color + " conresponding to a  type in the becher list");
        chemicalType = res;
        return success;
    }

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