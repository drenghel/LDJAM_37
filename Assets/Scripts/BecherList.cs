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

    void Start()
    {
        _spritesDictionary = new Dictionary<ChemicalType, Sprite>
        {
            {ChemicalType.Base, BaseBecherSprite},
            {ChemicalType.Red, RedBecherSprite},
            {ChemicalType.Blue, BlueBecherSprite},
            {ChemicalType.Green, GreenBecherSprite},
            {ChemicalType.Yellow, YellowBecherSprite},
            {ChemicalType.Orange, OrangeBecherSprite},
            {ChemicalType.Purple, PurpleBecherSprite},
        };


        _typesDictionary = new Dictionary<Sprite, ChemicalType>
        {
            {BaseBecherSprite, ChemicalType.Base},
            {RedBecherSprite, ChemicalType.Red},
            {BlueBecherSprite, ChemicalType.Blue},
            {GreenBecherSprite, ChemicalType.Green},
            {YellowBecherSprite, ChemicalType.Yellow},
            {OrangeBecherSprite, ChemicalType.Orange},
            {PurpleBecherSprite, ChemicalType.Purple}
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
}