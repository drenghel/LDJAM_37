using UnityEngine;

public class Becher : MonoBehaviour
{
    [ReadOnlyCustom] [SerializeField] protected ChemicalType _containingChemicalType = ChemicalType.Empty;

    [ReadOnlyCustom] [SerializeField] private Color _currentLiquidColor;

    [SerializeField] private SpriteRenderer _spriteRendererBecher;

    [SerializeField] private SpriteRenderer _spriteRendererLiquid;


    public ChemicalType ContainingChemicalType
    {
        get { return _containingChemicalType; }
    }

    protected Color CurrentLiquidColor
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
        _containingChemicalType = chemicalType;

        //TODO To remove later
        _spriteRendererBecher.sprite = FindObjectOfType<BecherList>().GetSpriteWithType(chemicalType);

        CurrentLiquidColor = FindObjectOfType<BecherList>().GetColorWithType(chemicalType);
        if (chemicalType == ChemicalType.Mixed)
            throw new UnityException("You can't assign a mixed color with that method");
    }

    private void BecherMixer(Becher stationBecher)
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
    Mixed
}