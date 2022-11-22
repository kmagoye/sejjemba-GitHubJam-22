using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class pancakeGame : MonoBehaviour
{
    player player;
    pancakePlayer pancakePlayer;
    public CinemachineVirtualCamera pancakeCamera;
    public CinemachineVirtualCamera returnCamera;


    private void Start()
    {
        player = FindObjectOfType<player>();
        pancakePlayer = FindObjectOfType<pancakePlayer>();

        pancakePlayer.enabled = false;
    }

    public void gameStart()
    {
        FindObjectOfType<camera_manager>().enabledCamera = pancakeCamera;

        player.enabled = false;

        pancakePlayer.enabled = true;
    }
}
