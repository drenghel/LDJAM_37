using System.Diagnostics;

public class LeftStation_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        
        SceneManager.ChangeCamera(SceneManager.GetSceneManager().LeftStationCamera);


    }
}
