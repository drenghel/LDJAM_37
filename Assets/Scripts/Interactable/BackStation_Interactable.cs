public class BackStation_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();


        MySceneManager.ChangeCamera(MySceneManager.GetSceneManager().BackStationCamera);

    }
}
