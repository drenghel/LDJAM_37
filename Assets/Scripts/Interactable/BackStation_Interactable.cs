public class BackStation_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();


        SceneManager.ChangeCamera(SceneManager.GetSceneManager().BackStationCamera);

    }
}
