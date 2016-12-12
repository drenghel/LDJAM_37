using UnityEngine;

public class PickingUp_Button : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _overSpriteRenderer;
    [SerializeField] MixerMachineBecher _mixerMachineBecher;

    private void OnMouseUpAsButton()
    {
        if (_mixerMachineBecher.ContainingChemicalType != ChemicalType.Empty)
        {
            PlayerBecher playerBecher = MySceneManager.GetPlayerController().BecherHeld;

            if (playerBecher.ContainingChemicalType == ChemicalType.None)
            {
                if (_mixerMachineBecher.ContainingChemicalType != ChemicalType.Mixed)
                {
                    playerBecher.EditBecher(_mixerMachineBecher.ContainingChemicalType);
                    _mixerMachineBecher.EditBecher(ChemicalType.Empty);
                }
                else
                {
                    playerBecher.EditBecher(_mixerMachineBecher.ContainingChemicalType);
                    playerBecher.CurrentLiquidColor = _mixerMachineBecher.CurrentLiquidColor;
                    _mixerMachineBecher.EditBecher(ChemicalType.Empty);
                }
            }
            else
            {
                Debug.LogError("You can't pick because you're helding a full Becher !");
            }
        }
        else
        {
            Debug.LogError("You can't pick that it's empty !");
        }
    }


    private void OnMouseOver()
    {
        _overSpriteRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        _overSpriteRenderer.enabled = false;
    }


    void Start()
    {
        _overSpriteRenderer.enabled = false;

    }
}