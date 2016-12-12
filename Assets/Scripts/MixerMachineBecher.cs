using UnityEngine;

public class MixerMachineBecher : Becher
{
    [SerializeField] SpriteRenderer _flowingLiquidRenderer_Left;
    [SerializeField] SpriteRenderer _flowingLiquidRenderer_Right;

    // Use this for initialization
    void Start()
    {
        EditBecher(ChemicalType.Empty);
    }

    public void ChangeColorOfFlowingLiquid(Color color, Side side)
    {
        if (side == Side.Left)
            _flowingLiquidRenderer_Left.color = color;
        if (side == Side.Right)
            _flowingLiquidRenderer_Right.color = color;
    }

    public void SetNewBecher(Color newColor)
    {
        if (ContainingChemicalType != ChemicalType.Empty)
        {
            Color mixedColor = BecherList.CombineColors(newColor, CurrentLiquidColor);
            ChemicalType res;
            bool success = BecherList.GetBecherList().GetTypeByColor(mixedColor, out res);
            if (success)
                EditBecher(res);
            else
            {
                EditBecher(ChemicalType.Mixed);
                CurrentLiquidColor = mixedColor;
            }
        }
        else
        {
            ChemicalType res;
            bool success = BecherList.GetBecherList().GetTypeByColor(newColor, out res);
            EditBecher(res);
        }
    }
}

public enum Side
{
    Right,
    Left
}