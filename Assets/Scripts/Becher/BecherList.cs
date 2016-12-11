using System.Collections.Generic;
using UnityEngine;

// ReSharper disable IdentifierTypo
public class BecherList : MonoBehaviour
{
    public Sprite RedBecherSprite;
    public Sprite GreenBecherSprite;
    public Sprite BlueBecherSprite;
    public Sprite PurpleBecherSprite;
    public Sprite OrangeBecherSprite;
    public Sprite YellowBecherSprite;
    public Sprite BaseBecherSprite;


    private Dictionary<ChemicalType, Sprite> _spritesDictionary;
    private Dictionary<Sprite, ChemicalType> _typesDictionary;
    private Dictionary<ChemicalType, Color> _colorsDictionary;

    void Awake()
    {
        _spritesDictionary = new Dictionary<ChemicalType, Sprite>
        {
            {ChemicalType.Base, BaseBecherSprite},
            {ChemicalType.Red, RedBecherSprite},
            {ChemicalType.Blue, BlueBecherSprite},
            {ChemicalType.Green, GreenBecherSprite}
        };


        _typesDictionary = new Dictionary<Sprite, ChemicalType>
        {
            {BaseBecherSprite, ChemicalType.Base},
            {RedBecherSprite, ChemicalType.Red},
            {BlueBecherSprite, ChemicalType.Blue},
            {GreenBecherSprite, ChemicalType.Green}
        };
        _colorsDictionary = new Dictionary<ChemicalType, Color>
        {
            {ChemicalType.Base, Color.white},
            {ChemicalType.Red, Color.red},
            {ChemicalType.Blue, Color.blue},
            {ChemicalType.Green, Color.green},
            {ChemicalType.Empty, Color.clear}
        };
    }


    public Sprite GetSpriteWithType(ChemicalType type)
    {
        switch (type)
        {
            case ChemicalType.Empty:
                return null;
            case ChemicalType.Mixed:
                throw new UnityException("Mixed Chemical has not been implemented !");
        }

        Sprite res;
        bool success = _spritesDictionary.TryGetValue(type, out res);
        if (success)
            return res;
        throw new UnityException("There is no " + type.ToString() + "sprite in the becher list");
    }


    public ChemicalType GetTypeOfSprite(Sprite sprite)
    {
        ChemicalType res;
        bool success = _typesDictionary.TryGetValue(sprite, out res);
        if (success)
            return res;
        throw new UnityException("There is no " + sprite.name + "type in the becher list");
    }

    public Color GetColorWithType(ChemicalType type)
    {
        Color res;
        bool success = _colorsDictionary.TryGetValue(type, out res);
        if (success)
            return res;
        throw new UnityException("There is no " + type + "color in the becher list");
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