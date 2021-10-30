using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChest : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer ClosedChestSprite;
    [HideInInspector] public BoxCollider2D ClosedChestCollider;

    public ParticleSystem Effect;

    public GameObject[] Disappearing;
    // Start is called before the first frame update
    void Start()
    {
        ClosedChestSprite = gameObject.GetComponent<SpriteRenderer>();
        ClosedChestCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Effect.Play();

            ClosedChestCollider.enabled = false;
            ClosedChestSprite.enabled = false;

            for (int i = 0; i < Disappearing.Length; i++)
            {
                Disappearing[i].SetActive(true);
            }

        }
    }
}
