using UnityEngine;

public class Becher : MonoBehaviour
{

    [ReadOnlyCustom]
    [SerializeField]
    private ChemicalType _containingChemicalType = ChemicalType.Empty;

    private SpriteRenderer _spriteRenderer;

    public ChemicalType ContainingChemicalType
    {
        get { return _containingChemicalType; }
    }


    public void Editbecher(ChemicalType chemicalType)
    {
        _containingChemicalType = chemicalType;
        _spriteRenderer.sprite = FindObjectOfType<BecherList>().GetSpriteWithType(chemicalType);
    }



    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        Editbecher(ChemicalType.Empty);
    }
}


public enum ChemicalType
{
    Empty,
    Red,
    Purple,
    Blue,
    Yellow,
    Orange,
    Green,
    Base,
    Mixed
}