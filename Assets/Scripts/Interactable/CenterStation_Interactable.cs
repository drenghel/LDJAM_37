public class CenterStation_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();
        MySceneManager.ChangeCamera(MySceneManager.GetSceneManager().CenterStationCamera);
    }
}