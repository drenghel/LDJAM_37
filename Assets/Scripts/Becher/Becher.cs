using UnityEngine;

public class Becher : MonoBehaviour
{
    [ReadOnlyCustom] [SerializeField] protected ChemicalType _containingChemicalType = ChemicalType.Empty;

    [ReadOnlyCustom] [SerializeField] protected Color _currentLiquidColor;

    [SerializeField] protected SpriteRenderer _spriteRendererBecher;

    [SerializeField] protected SpriteRenderer _spriteRendererLiquid;


    public ChemicalType ContainingChemicalType
    {
        get { return _containingChemicalType; }
    }

    public Color CurrentLiquidColor
    {
        get { return _currentLiquidColor; }
        set
        {
            _currentLiquidColor = value;
            _spriteRendererLiquid.color = _currentLiquidColor;
        }
    }


    public void EditBecher(ChemicalType chemicalType)
    {
        //Debug.Log(gameObject.name + " has been edited to " + chemicalType);
        _containingChemicalType = chemicalType;

        _spriteRendererBecher.sprite = chemicalType == ChemicalType.None
            ? null
            : BecherList.GetBecherList().EmptyBecherSprite;

        if (chemicalType == ChemicalType.Mixed)
            return; //gonna be handle later

        CurrentLiquidColor = FindObjectOfType<BecherList>().GetColorWithType(chemicalType);
    }

    protected void BecherMixer(Becher stationBecher)
    {
        CurrentLiquidColor = BecherList.CombineColors(CurrentLiquidColor, stationBecher.CurrentLiquidColor);
        _containingChemicalType = ChemicalType.Mixed;
    }
}


public enum ChemicalType
{
    Empty,
    Red,
    Blue,
    Green,
    Base,
    Mixed,
    None
}