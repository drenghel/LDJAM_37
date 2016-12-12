using UnityEngine;
using UnityEngine.SceneManagement;

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
        Color mixedColor;
        if (ContainingChemicalType != ChemicalType.Empty)
        {
            mixedColor = BecherList.CombineColors(newColor, CurrentLiquidColor);
        }
        else
            mixedColor = newColor;

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
}

public enum Side
{
    Right,
    Left
}