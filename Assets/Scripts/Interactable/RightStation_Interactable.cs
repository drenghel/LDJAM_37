using UnityEngine;

public class RightStation_Interactable : Interactable
{
    [SerializeField] GameObject MixerMachineGO;
    [SerializeField] Transform CloseUpTransform;

    protected override void Interact()
    {
        base.Interact();


        SceneManager.ChangeCamera(SceneManager.GetSceneManager().RightStationCamera);

        MoveMixerMachineToCloseUpSation();
    }


    void MoveMixerMachineToCloseUpSation()
    {
        MixerMachineGO.transform.SetParent(CloseUpTransform, false);
    }
}