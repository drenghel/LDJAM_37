public class CenterStation_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        SceneManager.ChangeCamera(SceneManager.GetSceneManager().CenterStationCamera);
    }
}