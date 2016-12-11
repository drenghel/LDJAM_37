public class RightStation_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();


        SceneManager.ChangeCamera(SceneManager.GetSceneManager().RightStationCamera);
    }
}