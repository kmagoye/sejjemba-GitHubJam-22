using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class door : MonoBehaviour
{
    public GameObject cameraObject;
    CinemachineVirtualCamera camera;
    camera_manager cameraManager;

    public door sisterDoor;
    public Transform target;
    player player;

    private void Start()
    {
        player = FindObjectOfType<player>();
        camera = cameraObject.GetComponent<CinemachineVirtualCamera>();
        cameraManager = FindObjectOfType<camera_manager>();
    }

    public void TP()
    {
        //moves player
        player.TP(sisterDoor.target.transform.position);

        //switches camera
        cameraManager.SetCamera(sisterDoor.camera);
    }
}
