using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTileset : MonoBehaviour
{
    public AudioSource BGMusic;
    public GameObject[] Hearts;
    public GameObject DeathCanvas;
    public int TotalHearts;
    public GameObject[] HeartHeal;
    //public Animator playerAnimator

    void Start()
    {
        TotalHearts = Hearts.Length;
        //playerAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < Hearts.Length; i++)
            {
                if(Hearts[i].activeInHierarchy)
                {
                    Hearts[i].SetActive(false);
                    TotalHearts--;
                    SoundManager.PlaySound("Hurt");
                    
                    if (TotalHearts == 1)
                    {
                        BGMusic.volume = 0.1f;
                        InvokeRepeating("TriggerDying", 0.001f, 3f);
                    }

                    break;
                }
            }
        }
    }

    void Update()
    {
        if (TotalHearts == 0)
        {
            DeathCanvas.SetActive(true);
            CancelInvoke();
            //playerAnimator.SetTrigger("Death");
        }

        if (TotalHearts > 1)
        {
            BGMusic.volume = 0.5f;
            CancelInvoke();
        }
    }

    public void TriggerDying()
    {
        SoundManager.PlaySound("LowHP");
    }
}
