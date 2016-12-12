using System.Diagnostics;

public class LeftStation_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        
        MySceneManager.ChangeCamera(MySceneManager.GetSceneManager().LeftStationCamera);


    }
}
