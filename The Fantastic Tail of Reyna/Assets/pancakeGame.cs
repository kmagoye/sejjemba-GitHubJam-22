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

    public GameObject pancake;

    public float verticalOffset;
    public float horizontalRange;


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

        spawnPancake();
    }

    public void spawnPancake()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-horizontalRange, horizontalRange), verticalOffset, 0) + transform.position;

        Instantiate(pancake, new Vector3(spawnPoint.x, spawnPoint.y, 10), transform.rotation);
    }
}
