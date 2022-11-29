using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    AudioSource audioSource;

    bool playing = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void setMusic(AudioClip song)
    {
        playing = false;

        audioSource.clip = song;

        audioSource.Play();

        playing = true;
    }

    private void Update()
    {
        if (playing)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();


            }
        }
    }
}
