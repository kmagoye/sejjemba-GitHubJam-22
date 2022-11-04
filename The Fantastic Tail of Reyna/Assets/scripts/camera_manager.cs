using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camera_manager : MonoBehaviour
{
    CinemachineVirtualCamera[] cameras;
    public CinemachineVirtualCamera enabledCamera;

    private void Start()
    {
        cameras = FindObjectsOfType<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        //sets the currently enabled camera as the highest priority, making the cinemachine brain switch to it
        foreach(CinemachineVirtualCamera camera in cameras)
        {
            if(camera.transform.name == enabledCamera.transform.name)
            {
                camera.Priority = 1;
            }
            else
            {
                camera.Priority = 0;
            }
        }
    }

    public void SetCamera(CinemachineVirtualCamera x)
    {
        enabledCamera = x;
    }
}
