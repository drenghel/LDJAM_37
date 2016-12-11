using UnityEngine;

public class SceneGetter : MonoBehaviour
{
    public static ScientistController GetPlayerController()
    {
        ScientistController[] scientistControllers = FindObjectsOfType<ScientistController>();
        if (scientistControllers.Length != 1)
            throw new UnityException("There can be ONLY ONE PLAYER !");
        return scientistControllers[0];
    }
}
