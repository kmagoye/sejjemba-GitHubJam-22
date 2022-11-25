using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class pancakeGame : MonoBehaviour
{
    pancakePlayer pancakePlayer;
    player player;
    public CinemachineVirtualCamera pancakeCamera;
    public CinemachineVirtualCamera returnCamera;

    public GameObject pancake;

    public float verticalOffset;
    public float horizontalRange;

    public dialougeTrigger dialougeTrigger;

    private void Start()
    {
        dialougeTrigger = GetComponent<dialougeTrigger>();

        player = FindObjectOfType<player>();
        pancakePlayer = FindObjectOfType<pancakePlayer>();

        pancakePlayer.enabled = false;
    }

    public void gameStart()
    {
        FindObjectOfType<camera_manager>().enabledCamera = pancakeCamera;

        pancakePlayer.enabled = true;

        dialougeTrigger.startDialouge();
    }

    public void gameEnd()
    {
        FindObjectOfType<camera_manager>().enabledCamera = returnCamera;
    }

    public void spawnPancake()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-horizontalRange, horizontalRange), verticalOffset, 0) + transform.position;

        Instantiate(pancake, new Vector3(spawnPoint.x, spawnPoint.y, 10), transform.rotation);
    }
}
