using UnityEngine;

public class ExitButton : MonoBehaviour {

    protected virtual void OnMouseUpAsButton()
    {
        GoBackToFullView();

    }

    public virtual void GoBackToFullView()
    {
        SceneManager.ChangeCamera(SceneManager.GetSceneManager().FullViewCamera);
    }
}
