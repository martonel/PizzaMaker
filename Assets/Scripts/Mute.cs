using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour
{
  private AudioSource audioSource;
    private bool isPaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isPaused)
            {
                audioSource.UnPause();
                isPaused = false;
            }
            else
            {
                audioSource.Pause();
                isPaused = true;
            }
        }
    }
}
