using UnityEngine;


public class AdvancedExit : ExitButton
{
    [SerializeField] GameObject MixerMachineGO;
    [SerializeField] Transform FullViewTransform;

    protected override void OnMouseUpAsButton()
    {
        GoBackToFullView();
    }


    void MoveMixerMachineToFullViewSation()
    {
        MixerMachineGO.transform.SetParent(FullViewTransform, false);
    }


    public override void GoBackToFullView()
    {
        base.GoBackToFullView();
        MoveMixerMachineToFullViewSation();

    }
}