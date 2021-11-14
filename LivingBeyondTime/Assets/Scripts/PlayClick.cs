using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayClick : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
