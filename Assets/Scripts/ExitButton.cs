using UnityEngine;

public class ExitButton : MonoBehaviour {

    private void OnMouseUpAsButton()
    {
        SceneManager.ChangeCamera(SceneManager.GetSceneManager().FullViewCamera);

    }


}
