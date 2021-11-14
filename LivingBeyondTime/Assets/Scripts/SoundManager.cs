using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip JumpSound, AttackSound, DeadSound, HurtSound, PickupKeySound, RespawnSound, LowHPSound, EnemyDeadSound, ClickSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        JumpSound = Resources.Load<AudioClip>("Jump");
        AttackSound = Resources.Load<AudioClip>("Attack");
        DeadSound = Resources.Load<AudioClip>("Dead");
        HurtSound = Resources.Load<AudioClip>("Hurt");
        PickupKeySound = Resources.Load<AudioClip>("Pickup_Key");
        RespawnSound = Resources.Load<AudioClip>("Respawn");
        LowHPSound = Resources.Load<AudioClip>("LowHP");

        EnemyDeadSound = Resources.Load<AudioClip>("EnemyDead");

        ClickSound = Resources.Load<AudioClip>("Click");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;

            case "Attack":
                audioSrc.PlayOneShot(AttackSound);
                break;

            case "Dead":
                audioSrc.PlayOneShot(DeadSound);
                break;

            case "Hurt":
                audioSrc.PlayOneShot(HurtSound);
                break;

            case "Pickup_Key":
                audioSrc.PlayOneShot(PickupKeySound);
                break;

            case "Respawn":
                audioSrc.PlayOneShot(RespawnSound);
                break;

            case "LowHP":
                audioSrc.PlayOneShot(LowHPSound);
                break;

            case "EnemyDead":
                audioSrc.PlayOneShot(EnemyDeadSound);
                break;

            case "Click":
                audioSrc.PlayOneShot(ClickSound);
                break;
        }

    }
}
