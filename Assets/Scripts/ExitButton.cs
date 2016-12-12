using UnityEngine;

public class ExitButton : MonoBehaviour {

    protected virtual void OnMouseUpAsButton()
    {
        GoBackToFullView();

    }

    public virtual void GoBackToFullView()
    {
        MySceneManager.ChangeCamera(MySceneManager.GetSceneManager().FullViewCamera);
    }
}
