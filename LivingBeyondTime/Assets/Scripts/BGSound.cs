using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSound : MonoBehaviour
{
    public static AudioClip WhatIsLoveSound, DungeonSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        WhatIsLoveSound = Resources.Load<AudioClip>("FreeWhatIsLove");
        DungeonSound = Resources.Load<AudioClip>("FreeDungeonMusic");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    public void PlayWhatIsLoveMusic()
    {
        audioSrc.clip = BGSound.WhatIsLoveSound;
        audioSrc.Play();
    }

    public void PlayDungeonMusic()
    {
        audioSrc.clip = BGSound.DungeonSound;
        audioSrc.Play();
    }
}
