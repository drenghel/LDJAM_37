using System.Collections.Generic;
using UnityEngine;

public class MySceneManager : MonoBehaviour
{
    public Camera FullViewCamera;
    public Camera RightStationCamera;
    public Camera LeftStationCamera;
    public Camera BackStationCamera;
    public Camera CenterStationCamera;

    private static List<Camera> _cameras;


    void Start()
    {
        _cameras = new List<Camera>
        {
            FullViewCamera,
            RightStationCamera,
            LeftStationCamera,
            BackStationCamera,
            CenterStationCamera
        };
        DisableAllCameras();
        FullViewCamera.enabled = true;
    }


    public static ScientistController GetPlayerController()
    {
        ScientistController[] scientistControllers = FindObjectsOfType<ScientistController>();
        if (scientistControllers.Length != 1)
            throw new UnityException("There can be ONLY ONE PLAYER !");
        return scientistControllers[0];
    }

    public static void ChangeCamera(Camera camera)
    {
        DisableAllCameras();

        camera.enabled = true;
    }

    private static void DisableAllCameras()
    {
        foreach (Camera camera in _cameras)
        {
            camera.enabled = false;
        }
    }


    public static MySceneManager GetSceneManager()
    {
        var sMs = FindObjectsOfType<MySceneManager>();
        if (sMs.Length != 1)
            throw new UnityException("There can only be one SceneManger");
        return sMs[0];
    }


}